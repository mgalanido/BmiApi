using BmiApi.Interfaces;
using BmiApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BmiApi.Controllers
{
    /// <summary>
    /// API Controller for BMI Calculations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BmiController : ControllerBase
    {
        private readonly IBmiService _bmiService;

        /// <summary>
        /// Initializing new instance.
        /// </summary>
        /// <param name="bmiService">The BMI Service</param>
        public BmiController(IBmiService bmiService)
        {
            _bmiService = bmiService;
        }

        /// <summary>
        /// Calculates the BMI based on the given height and weight.
        /// </summary>
        /// <param name="request">The BMI request containing height and weight.</param>
        /// <returns>A response containing the calculated BMI and BMI category.</returns>
        [HttpPost]
        public IActionResult CalculateBmi([FromBody] BmiRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = _bmiService.CalculateBmi(request.Height, request.Weight);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
