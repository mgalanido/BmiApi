using BmiApi.Models;

namespace BmiApi.Interfaces
{
    /// <summary>
    /// Defines methods for calculating BMI.
    /// </summary>
    public interface IBmiService
    {
        /// <summary>
        /// Calculates the BMI based on height (in cm) and weight (in kg)
        /// </summary>
        /// <param name="height">The height in centimeters</param>
        /// <param name="weight">The weight in kilograms</param>
        /// <returns>A <see cref="BmiResponse"/> containing the calculated BMI and the BMI category.</returns>
        BmiResponse CalculateBmi(double height, double weight);
    }
}
