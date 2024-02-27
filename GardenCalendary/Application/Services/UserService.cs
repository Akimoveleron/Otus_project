using Application.Interfaces;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGardenCalendaryContext _context;
        public UserService(IGardenCalendaryContext context)
        {
            _context = context;
        }

        public async Task AddUserInRole(int userId, string roleName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new NullReferenceException("Пользователь с таким Id не найден");
            }

            var role = await _context.Roles.FirstOrDefaultAsync(u => u.Name == roleName);
            if (role == null)
            {
                throw new NullReferenceException("Роль с таким именем не найдена");
            }

            try
            {
                await _context.UserRoles.AddAsync(new IdentityUserRole<int>
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Не удалось добавить в роль, возможно имя роли неверно");
            }
        }
    }
}
