using System.ComponentModel.DataAnnotations;

namespace BmiApi.Models
{
    /// <summary>
    /// Represents a request to calculate BMI
    /// </summary>
    public class BmiRequest
    {
        /// <summary>
        /// The Height in centimeters.
        /// Must be a positive value.
        /// </summary>
        [Range(0.1, double.MaxValue, ErrorMessage = "Height must be a positive value.")]
        public double Height { get; set; }

        /// <summary>
        /// The Weight in kilograms.
        /// Must be a positive value.
        /// </summary>
        [Range(0.1, double.MaxValue, ErrorMessage = "Weight must be a positive value.")]
        public double Weight { get; set; }
    }
}
