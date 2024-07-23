using BmiApi.Controllers;
using BmiApi.Interfaces;
using BmiApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Dynamic;

namespace BmiApi.Tests
{
    public class BmiControllerTests
    {
        private readonly BmiController _controller;
        private readonly Mock<IBmiService> _mockBmiService;

        public BmiControllerTests()
        {
            _mockBmiService = new Mock<IBmiService>();
            _controller = new BmiController(_mockBmiService.Object);
        }

        [Fact]
        public void CalculateBmi_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var request = new BmiRequest { Height = -170, Weight = 70 };
            _controller.ModelState.AddModelError("Height", "Height must be a positive value.");
            _controller.ModelState.AddModelError("Weight", "Weight must be a positive value.");

            // Act
            var result = _controller.CalculateBmi(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var serializableError = Assert.IsType<SerializableError>(badRequestResult.Value);

            // Extract errors from SerializableError
            var errors = (IDictionary<string, object>)serializableError;

            // Validate error messages
            Assert.True(errors.ContainsKey("Height"));
            Assert.Contains("Height must be a positive value.", (IEnumerable<string>)errors["Height"]);

            Assert.True(errors.ContainsKey("Weight"));
            Assert.Contains("Weight must be a positive value.", (IEnumerable<string>)errors["Weight"]);
        }

        [Fact]
        public void CalculateBmi_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var request = new BmiRequest { Height = 175, Weight = 85 };
            var expectedResponse = new BmiResponse { Bmi = 27.76, Category = "Normal weight" };

            _mockBmiService.Setup(service => service.CalculateBmi(request.Height, request.Weight))
                           .Returns(expectedResponse);

            // Act
            var result = _controller.CalculateBmi(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<BmiResponse>(okResult.Value);
            Assert.Equal(expectedResponse.Bmi, response.Bmi);
            Assert.Equal(expectedResponse.Category, response.Category);
        }
    }
}
