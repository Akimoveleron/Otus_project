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
    public class RReestrObjectsController : ControllerBase
    {
        private readonly IGenericRepository<RReestrObject, RReestrObjectModel> _repository;

        public RReestrObjectsController(IGenericRepository<RReestrObject, RReestrObjectModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Получить все адреса
        /// </summary>
        /// <returns></returns>
        [EnableCors("AllowAllOrigins")]
        [HttpGet]
        public async Task<ActionResult<IList<RReestrObjectModel>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowAllOrigins")]
        public async Task<ActionResult<RReestrObjectModel>> GetById(int id)
        {
            return Ok(await _repository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] RReestrObjectModel rReestrObject)
        {
            await _repository.AddAsync(rReestrObject);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Change(int id, [FromBody] RReestrObjectModel rReestrObject)
        {
            await _repository.UpdateAsync(id, rReestrObject);
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
