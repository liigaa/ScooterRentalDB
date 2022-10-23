using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;

namespace ScooterRental.Controllers
{
    [Route("api-scooter")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _scooterService;

        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        [HttpPost]
        public IActionResult AddScooter(Scooter scooter)
        {
            var exists = _scooterService.ScooterExists(scooter.Id);

            if (exists)
            {
                return BadRequest();
            }
            _scooterService.Create(scooter);

            return Ok();
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetScooter(string id)
        {
            var scooter = _scooterService.GetById(id);

            if (scooter == null)
            {
                return NotFound();
            }

            return Ok(scooter);
        }

        [Route("all-available")]
        [HttpGet]
        public IActionResult GetAllAvailableScooters()
        {
            var scooters = _scooterService.GetAvailableScooters();

            return Ok(scooters);
        }

        [Route("all")]
        [HttpGet]
        public IActionResult GetAllScooters()
        {
            var scooters = _scooterService.GetAll();

            return Ok(scooters);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteScooter(string id)
        {
            var scooter = _scooterService.GetById(id);

            if (scooter == null)
            {
                return NotFound();
            }

            _scooterService.Delete(scooter);

            return Ok();
        }
    }
}
