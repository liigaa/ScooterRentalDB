using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Services;

namespace ScooterRental.Controllers
{
    [Route("api-rent")]
    [ApiController]
    public class RentScooterController : ControllerBase
    {
        private readonly IRentedScooterService _rentedScooterService;
        private readonly IScooterService _scooterService;

        public RentScooterController(IRentedScooterService rentedScooterService,
            IScooterService scooterService)
        {
            _rentedScooterService = rentedScooterService;
            _scooterService = scooterService;
        }

        [Route("start-rent/{id}")]
        [HttpPut]
        public IActionResult StartRent(string id)
        {
            var scooter = _scooterService.GetById(id);

            if (scooter == null)
            {
                return NotFound();
            }

            _scooterService.UpdateScooterAvailability(scooter);
            _rentedScooterService.StartRent(scooter);

            return Ok();
        }
    }
}
