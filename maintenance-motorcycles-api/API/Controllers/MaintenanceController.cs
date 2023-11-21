using Application.Interface;
using Data.Entity.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/maintenance")]
    public class MaintenanceController : ControllerBase
    {
        private readonly ILogger<MaintenanceController> _logger;
        private readonly MaintenanceService _maintenanceService;

        public MaintenanceController(ILogger<MaintenanceController> logger, MaintenanceService maintenanceService)
        {
            _logger = logger;
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            var maintenances = await _maintenanceService.GetAll();

            return Ok(maintenances);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetById(int id)
        {
            var maintenance = await _maintenanceService.GetById(id);

            return Ok(maintenance);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(MaintenanceEntity maintenance)
        {
            var maintenanceInserted = await _maintenanceService.AddMaintenance(maintenance);

            return CreatedAtAction(nameof(Get), new { Id = maintenance.Id }, maintenance);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(int id, MaintenanceEntity maintenance)
        {
            await _maintenanceService.UpdateMaintenance(id, maintenance);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            await _maintenanceService.RemoveMaintenance(id);

            return NoContent();
        }
    }
}