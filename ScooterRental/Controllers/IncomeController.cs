using Microsoft.AspNetCore.Mvc;
using ScooterRental.Core.Services;

namespace ScooterRental.Controllers
{
    [Route("api-income")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IRentedScooterService _rentedScooterService;

        public IncomeController(IRentedScooterService rentedScooterService)
        {
            _rentedScooterService = rentedScooterService;
        }

        [Route("all-finished")]
        [HttpGet]
        public IActionResult GetAllFinishedRentIncome()
        {
            var result = _rentedScooterService.GetAllFinishedRentedSum();

            return Ok(result);
        }

        [Route("all-unfinished")]
        [HttpGet]
        public IActionResult GetAllUnFinishedRentIncome()
        {
            var result = _rentedScooterService.GetNotFinishedRentalIncome(null);

            return Ok(result);
        }
    }
}
