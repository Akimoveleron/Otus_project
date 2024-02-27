using Application.Interfaces;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IGardenCalendaryContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAutomapperConfig _automapperConfig;
        private readonly Mapper _mapper;
        public AuthService(IConfiguration configuration, IGardenCalendaryContext context,
            UserManager<User> userManager, RoleManager<Role> roleManager, IAutomapperConfig automapperConfig)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _automapperConfig = automapperConfig;
            _mapper = _automapperConfig.InitializeAutomapper();
        }

        public async Task<TokenModel> Autorize(User user)
        {
            var token = await GetToken(user);

            return new TokenModel { Token = token, UserId = user.Id};
        }

        public async Task<string> GetToken(User user)
        {
            var resString = string.Empty;

            var token = await _context.UserTokens.FirstOrDefaultAsync(x => x.UserId == user.Id && x.ExpirationDate > DateTime.Now.ToUniversalTime());

            //если не нашли в БД
            if (token == null)
            {
                var claims = new List<Claim>();
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                {
                    var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == "user");
                    await _context.UserRoles.AddAsync(new IdentityUserRole<int>
                    {
                        RoleId = role is null ? 0 : role.Id,
                        UserId = user.Id
                    });
                    _context.SaveChanges();
                    roles.Add("user");
                }
                
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken();
                var expirationDate = DateTime.UtcNow;

                claims.Add(new Claim(ClaimTypes.Role, roles.FirstOrDefault()!));
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                expirationDate = expirationDate.AddMonths(1);
                tokenOptions = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"],
                    claims: claims, expires: expirationDate, signingCredentials: signinCredentials);

                resString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                //запись в БД
                await _context.UserTokens.AddAsync(new UserToken
                {
                    ExpirationDate = expirationDate,
                    UserId = user.Id,
                    Value = resString
                });
                _context.SaveChanges();

            }
            //если нашли в БД
            else
            {
                return token.Value;
            }


            return resString;
        }

        public async Task<TokenModel> RefreshToken(TokenModel token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                ValidateLifetime = true, //here we are saying that we care about the token's expiration date
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token.Token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            var tokentut = _context.UserTokens.FirstOrDefault(x => x.Value == token.Token);
            if (jwtSecurityToken == null
                || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase)
                || principal.Claims.Count() == 0 || tokentut is null || tokentut.ExpirationDate < DateTime.UtcNow)
                throw new InvalidTokenException("Невалидный токен: refresh просрочен");

            var claim = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            if (claim == null || claim.Value == null)
                throw new InvalidTokenException("Невалидный токен: подделка access");

            var user = _userManager.Users.SingleOrDefault(r => r.UserName == claim.Value);
            if (user == null)
            {
                throw new InvalidTokenException("Невалидный токен: не найден пользователь");
            }

            token.Token = await GetToken(user);


            return token;
        }

        public async Task<TokenModel> Registration(RegistrationModel registrationModel)
        {
            var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.UserName == registrationModel.UserName);
            if (userInDb is not null)
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }

            await _context.Users.AddAsync(new User
            {
                Password = registrationModel.Password,
                Email = registrationModel.Email,
                UserName = registrationModel.UserName
            });
            _context.SaveChanges();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == registrationModel.UserName);
            if (user is null)
            {
                throw new Exception("Ошибка сохранения пользователя");
            }
            var token = await Autorize(user);
            return token;
        }
    }
}
