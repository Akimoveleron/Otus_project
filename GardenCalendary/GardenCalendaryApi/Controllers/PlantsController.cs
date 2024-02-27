using Domain.Entities;
using Domain.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlantsController : ControllerBase
    {
        private readonly IGenericRepository<RPlant, RPlantModel> _repository;

        public PlantsController(IGenericRepository<RPlant, RPlantModel> repository)
        {
            _repository = repository;
        }

        //[Authorize(Roles = "user")]
        //[Authorize(Roles = "admin")]
        [EnableCors("AllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IList<RPlantModel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RPlantModel>> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] RPlantModel plant)
        {
            await _repository.AddAsync(plant);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Change(int id, [FromBody] RPlantModel plant)
        {
            await _repository.UpdateAsync(id, plant);
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
