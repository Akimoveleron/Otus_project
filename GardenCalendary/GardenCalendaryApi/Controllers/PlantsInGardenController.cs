using Domain.Entities;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsInGardenController : ControllerBase
    {
        private readonly IGenericRepository<PlantInGarden, PlantInGardenModel> _repository;

        public PlantsInGardenController(IGenericRepository<PlantInGarden, PlantInGardenModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PlantInGardenModel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantInGardenModel>> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PlantInGardenModel plantInGarden)
        {
            await _repository.AddAsync(plantInGarden);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Change(int id, [FromBody] PlantInGardenModel plantInGarden)
        {
            await _repository.UpdateAsync(id, plantInGarden);
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
