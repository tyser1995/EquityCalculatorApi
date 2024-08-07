using Microsoft.AspNetCore.Mvc;
using EquityCalculatorApi.Models;
using EquityCalculatorApi.Services;
using System;

namespace EquityCalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquityController : ControllerBase
    {
        private readonly EquityCalculatorService _equityCalculatorService;

        public EquityController(EquityCalculatorService equityCalculatorService)
        {
            _equityCalculatorService = equityCalculatorService;
        }

        [HttpPost("calculate")]
        public IActionResult CalculateEquity([FromBody] EquityCalculationRequest request)
        {
            if (request == null || request.SellingPrice <= 0 || request.EquityTerm <= 0)
            {
                return BadRequest("Invalid input.");
            }

            var result = _equityCalculatorService.CalculateEquity(
                request.SellingPrice,
                request.ReservationDate,
                request.EquityTerm
            );

            return Ok(result);
        }
    }

    public class EquityCalculationRequest
    {
        public decimal SellingPrice { get; set; }
        public DateTime ReservationDate { get; set; }
        public int EquityTerm { get; set; }
    }
}
