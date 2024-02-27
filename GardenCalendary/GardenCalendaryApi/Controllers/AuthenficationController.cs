using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Models;
using Infrastructure;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly GardenCalendaryContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IAuthService _authService;
        private readonly IGenericRepository<User, UserModel> _userRepository;

        public AuthenticationController(
            IConfiguration configuration, GardenCalendaryContext context,
            UserManager<User> userManager, IAuthService authService, 
            IGenericRepository<User, UserModel> userRepository)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
            _authService = authService;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        [EnableCors("AllowAllOrigins")]
        public async Task<ActionResult<TokenModel>> Login([FromBody] AuthModel auth)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(r => r.UserName == auth.Login && r.Password == auth.Password);
            if (user is null)
            {
                var json = new JsonResult("Неверный логин и/или пароль");
                return Unauthorized(json);
            }

            var token = await _authService.Autorize(user);
            //var accessT = _authService.GetToken(user, TokenTypeEnum.Access);
            //var refreshT = _authService.GetToken(user, TokenTypeEnum.Refresh);
            //var token = new TokenModel { Access = accessT, Refresh = refreshT };
            //_context.SaveChanges();// TO DO: Подумать, почему не получается сохранить изменения внутри метода gettoken
            return Ok(token);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<TokenModel>> RefreshToken([FromBody] TokenModel token) //приходят access и refresh токены
        {
            await _authService.RefreshToken(token);
            return Ok(token);
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost("Registration")]
        public async Task<ActionResult<TokenModel>> Registration([FromBody] RegistrationModel registrationModel)
        {
            try
            {
                return Ok(await _authService.Registration(registrationModel));
            }
            catch (Exception e)
            {
                // Errors
                return Unauthorized(e.Message);
            }
        }
    }
}