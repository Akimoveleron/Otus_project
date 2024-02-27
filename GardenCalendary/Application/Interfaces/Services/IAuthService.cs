using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAuthService
    {
        public Task<TokenModel> Autorize(User user);
        public Task<TokenModel> RefreshToken(TokenModel token);
        public Task<TokenModel> Registration(RegistrationModel registrationModel);
    }
}
