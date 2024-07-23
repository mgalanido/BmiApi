using BmiApi.Interfaces;
using BmiApi.Models;

namespace BmiApi.Services
{
    /// <summary>
    /// Service for calculating BMI
    /// </summary>
    public class BmiService : IBmiService
    {
        /// <summary>
        /// Calculates the BMI based on height (in cm) and weight (in kg)
        /// </summary>
        /// <param name="height">The height in centimeters</param>
        /// <param name="weight">The weight in kilograms</param>
        /// <returns>A <see cref="BmiResponse"/> containing the calculated BMI and the BMI category.</returns>
        public BmiResponse CalculateBmi(double height, double weight)
        {
            try
            {
                if (height <= 0 || weight <= 0)
                {
                    throw new ArgumentException("Height and weight must be in positive values.");
                }

                double mHeight = height / 100;
                double bmi = weight / (mHeight * mHeight);

                string category = bmi switch
                {
                    < 18.5 => "Underweight",
                    < 24.9 => "Normal weight",
                    < 29.9 => "Overweight",
                    _ => "Obesity"
                };

                return new BmiResponse
                {
                    Bmi = Math.Round(bmi, 2),
                    Category = category,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
