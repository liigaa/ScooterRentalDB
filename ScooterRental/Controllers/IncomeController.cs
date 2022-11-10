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

        [Route("all-income/{year}")]
        [HttpGet]
        public IActionResult GetAllRentIncomeByYear(int year)
        {
            var result = _rentedScooterService.GetNotFinishedRentalIncome(year) 
                         + _rentedScooterService.GetAllFinishedRentalIncomeByYear(year);

            return Ok(result);
        }

        [Route("all-finished/{year}")]
        [HttpGet]
        public IActionResult GetAllFinishedRentIncomeByYear(int year)
        {
            var result = _rentedScooterService.GetAllFinishedRentalIncomeByYear(year);

            return Ok(result);
        }
    }
}
