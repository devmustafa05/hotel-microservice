using HotelManager.Api.Controllers;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelManager.API.Tests
{
    public class HotelControllerTest
    {

        private Mock<IMediator> _mockMediator;
        private HotelController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new HotelController(_mockMediator.Object);
        }

        [Test]
        public async Task GetAllHotels_ShouldReturnOkResult_WhenHotelsExist()
        {
            // Arrange
            var expectedHotels = new List<GetAllHotelsQueryResponse>();

            // Mock Mediator to return expected hotels

            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllHotelsQueryRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedHotels);

            // Act
            var result = await _controller.GetAllHotels();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(expectedHotels, okResult.Value);

        }
    }
}
