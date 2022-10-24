using System;
using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core;
using ScooterRental.Core.Services;

namespace ScooterRental.Controllers
{
    [Route("api-rent")]
    [ApiController]
    public class RentScooterController : ControllerBase
    {
        private readonly IRentedScooterService _rentedScooterService;
        private readonly IScooterService _scooterService;
        private readonly IIncomeCalculation _calculation;

        public RentScooterController(IRentedScooterService rentedScooterService,
            IScooterService scooterService,
            IIncomeCalculation calculation)
        {
            _rentedScooterService = rentedScooterService;
            _scooterService = scooterService;
            _calculation = calculation;
        }

        [Route("start-rent/{id}")]
        [HttpPut]
        public IActionResult StartRent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var scooter = _scooterService.GetAvailableScooterById(id);

            if (scooter == null)
            {
                return NotFound();
            }

            _scooterService.UpdateScooterIsRentedToTrue(scooter);
            _rentedScooterService.StartRent(scooter);

            return Ok();
        }

        [Route("end-rent/{id}")]
        [HttpPut]
        public IActionResult EndRent(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var scooter = _scooterService.GetRentedScooterById(id);
            var rentedScooter = _rentedScooterService.GetRentedScooter(id);

            if (scooter == null || rentedScooter == null)
            {
                return NotFound();
            }

            _scooterService.UpdateScooterIsRentedToFalse(scooter);

            rentedScooter.EndTime = DateTime.UtcNow;
            var totalPrice = _calculation.GetRentedScooterFee(rentedScooter);
            rentedScooter.TotalPrice = totalPrice;
            _rentedScooterService.Update(rentedScooter);

            return Ok();
        }
    }
}
