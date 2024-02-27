using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Models.Data;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GardenModel = Domain.Models.GardenModel;

namespace API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardensController : ControllerBase
    {
        private readonly IGenericRepository<Garden, GardenModel> _repository;
        private readonly IGardenService _gardenService;

        public GardensController(IGenericRepository<Garden, GardenModel> repository,
            IGardenService gardenService)
        {
            _repository = repository;
            _gardenService = gardenService;
        }

        [HttpGet("{userId}")]
        [EnableCors("AllowAllOrigins")]
        public async Task<UpdateModel> GetData(int userId) 
            => await _gardenService.GetData(userId);
        
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public async Task<UpdateModel> SetData(UpdateModel model)
            => await _gardenService.SetData(model);

        // [HttpGet]
        // public async Task<ActionResult<IList<GardenModel>>> GetAll()
        // {
        //     return Ok(await _repository.GetAllAsync());
        // }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<GardenModel>> GetById(int id)
        // {
        //     return Ok(await _repository.GetByIdAsync(id));
        // }

        // [EnableCors("AllowAllOrigins")]
        // [HttpGet("GetAllByUserId/{userId}")]
        // public async Task<ActionResult<List<Garden>>> GetAllByUserId(int userId)
        // {
        //     return Ok(await _gardenService.GetAllByUserId(userId));
        // }
        //
        // [EnableCors("AllowAllOrigins")]
        // [HttpPost]
        // public async Task<GardenModel> Add([FromBody] GardenModel garden) 
        //     => await _repository.AddAsync(garden);
        //
        // [HttpPut("{id}")]
        // public async Task<ActionResult> Change(int id, [FromBody] GardenModel garden)
        // {
        //     await _repository.UpdateAsync(id, garden);
        //     return Ok();
        // }
        //
        // [HttpDelete("{id}")]
        // public async Task<ActionResult> Remove(int id)
        // {
        //     await _repository.DeleteAsync(id);
        //     return Ok();
        // }
    }
}
