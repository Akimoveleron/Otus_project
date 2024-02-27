using GardeningTipsService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GardeningTipsService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulationController : Controller
    {
        private readonly IGardeningSimulationService _simulationService;


        public SimulationController(IGardeningSimulationService simulationService)
        {
            _simulationService = simulationService;
        }


        [HttpGet("GardenId")]
        public async Task<ActionResult> GarderingSimulation(int gardenId)
        {
            await _simulationService.UserSimulation(gardenId);
            return Ok();
        }
    }
}
