using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Models;
using ScooterRental.Core.Services;
using ScooterRental.Core.Validations;

namespace ScooterRental.Controllers
{
    [Route("api-scooter")]
    [ApiController]
    public class ScooterController : ControllerBase
    {
        private readonly IScooterService _scooterService;
        private readonly IEnumerable<IScooterValidator> _scooterValidators;

        public ScooterController(IScooterService scooterService,
            IEnumerable<IScooterValidator> scooterValidators)
        {
            _scooterService = scooterService;
            _scooterValidators = scooterValidators;
        }

        [HttpPost]
        public IActionResult AddScooter(Scooter scooter)
        {
            var exists = _scooterService.ScooterExists(scooter.Id);

            if (!_scooterValidators.All(s => s.IsValid(scooter)) || 
                exists)
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
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
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
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var scooter = _scooterService.GetById(id);

            if (scooter == null)
            {
                return NotFound();
            }

            if (scooter.IsRented)
            {
                return BadRequest();
            }

            _scooterService.Delete(scooter);

            return Ok();
        }
    }
}
