using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User, UserModel> _repository;
        private readonly IUserService _userService;

        public UsersController(IGenericRepository<User, UserModel> repository,
            IUserService userService)
        {
            _repository = repository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserModel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [EnableCors("AllowAllOrigins")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserModel User)
        {
            await _repository.AddAsync(User);
            return Ok();
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Change(int id, [FromBody] UserModel User)
        {
            await _repository.UpdateAsync(id, User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }

        [Route("AddUserInRole")]
        [HttpPost]
        public async Task<ActionResult> AddUserInRole(int userId, string roleName)
        {
            await _userService.AddUserInRole(userId, roleName);
            return Ok();
        }
    }
}
