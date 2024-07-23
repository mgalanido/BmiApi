using BmiApi.Interfaces;
using BmiApi.Services;

namespace BmiApi.Tests
{
    public class BmiServiceTests
    {
        private readonly IBmiService _bmiService;

        public BmiServiceTests()
        {
            _bmiService = new BmiService();
        }

        [Theory]
        [InlineData(170, 50, 17.30, "Underweight")]
        [InlineData(170, 70, 24.22, "Normal weight")]
        [InlineData(170, 85, 29.41, "Overweight")]
        [InlineData(170, 100, 34.60, "Obesity")]
        public void CalculateBmi_ReturnsExpectedResult(double height, double weight, double expectedBmi, string expectedCategory)
        {
            // Act
            var result = _bmiService.CalculateBmi(height, weight);

            // Assert
            Assert.Equal(expectedBmi, result.Bmi);
            Assert.Equal(expectedCategory, result.Category);
        }

        [Fact]
        public void CalculateBmi_InvalidHeight_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _bmiService.CalculateBmi(-170, 70));
        }

        [Fact]
        public void CalculateBmi_InvalidWeight_ThrowsArgumentException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _bmiService.CalculateBmi(170, -70));
        }
    }
}
