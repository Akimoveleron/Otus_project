using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGardensController : ControllerBase
    {
        private readonly IGenericRepository<UserGarden, UserGardenModel> _repository;

        public UserGardensController(IGenericRepository<UserGarden, UserGardenModel> repository,
            IGardenService gardenService)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserGardenModel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserGardenModel>> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public async Task<ActionResult> Add([FromBody] UserGardenModel garden)
        {
            await _repository.AddAsync(garden);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Change(int id, [FromBody] UserGardenModel garden)
        {
            await _repository.UpdateAsync(id, garden);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok();
        }
    }
}
