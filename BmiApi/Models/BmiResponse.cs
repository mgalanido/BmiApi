namespace BmiApi.Models
{
    /// <summary>
    /// Represents the response containing BMI calculation result.
    /// </summary>
    public class BmiResponse
    {
        /// <summary>
        /// The calculated BMI
        /// </summary>
        public double Bmi { get; set; }

        /// <summary>
        /// The BMI Category (Underweight, Normal weight, Overweight, Obesity)
        /// </summary>
        public string Category { get; set; } = default!;
    }
}
