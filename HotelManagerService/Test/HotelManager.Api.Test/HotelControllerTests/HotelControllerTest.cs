using HotelManager.Api.Controllers;
using HotelManager.Application.DTOs.Hotels;
using HotelManager.Application.Features.Hotels.Command.CreateHotel;
using HotelManager.Application.Features.Hotels.Query.GetAllHotels;
using HotelManager.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HotelManager.API.Tests.HotelManagerApiTests.HotelControllerTest.GetAllHotels
{
    public class GetAllHotelApiTest
    {
        private Mock<IMediator> mockMediator;
        private HotelController controller;

        [SetUp]
        public void Setup()
        {
            mockMediator = new Mock<IMediator>();
            controller = new HotelController(mockMediator.Object);
        }

        [Test]
        public async Task GetAllHotels_ShouldReturnOkResult_WhenHotelsExist()
        {
            // Arrange
            var expectedHotels = new List<GetAllHotelsQueryResponse>();

            mockMediator.Setup(m => m.Send(It.IsAny<GetAllHotelsQueryRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedHotels);

            // Act
            var result = await controller.GetAllHotels();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(expectedHotels));
        }


        [Test]
        public async Task GetAllHotels_ShouldReturnCorrectHotels_WhenHotelsExist()
        {
            // Arrange
            var expectedHotels = GetSampleHotels();

            mockMediator.Setup(m => m.Send(It.IsAny<GetAllHotelsQueryRequest>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedHotels);

            // Act
            var result = await controller.GetAllHotels();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var returnedHotels = okResult.Value as List<GetAllHotelsQueryResponse>;
            Assert.IsNotNull(returnedHotels);
            Assert.That(returnedHotels.Count, Is.EqualTo(expectedHotels.Count));

            for (int i = 0; i < expectedHotels.Count; i++)
            {
                AssertHotelEquality(expectedHotels[i], returnedHotels[i]);
            }
        }

        private List<GetAllHotelsQueryResponse> GetSampleHotels()
        {
            return new List<GetAllHotelsQueryResponse>
            {
                new GetAllHotelsQueryResponse
                {
                    Id = 1,
                    Name = "Hotel A",
                    LocationName = "Location-1",
                    Latitude = 40.8m,
                    Longitude = -74.5m,
                    HotelOfficials = new List<HotelOfficialDto>
                    {
                        new HotelOfficialDto { Name = "Mustafa", SurName = "Yener", CorporateTitle = "Müdür" }
                    },
                    Locations = new List<LocationDto>
                    {
                        new LocationDto { Name = "Locations => Location 1", Latitude = 40.7128m, Longitude = -74.0060m }
                    }
                },
                new GetAllHotelsQueryResponse
                {
                    Id = 2,
                    Name = "Hotel B",
                    LocationName = "Location-2",
                    Latitude = 34.5m,
                    Longitude = -118.8m,
                    HotelOfficials = new List<HotelOfficialDto>
                    {
                        new HotelOfficialDto { Name = "Mustafa", SurName = "Yener", CorporateTitle = "Müdür" }
                    },
                    Locations = new List<LocationDto>
                    {
                        new LocationDto { Name = "Locations => Location 2", Latitude = 34.0522m, Longitude = -118.2437m }
                    }
                }
            };
        }

        private void AssertHotelEquality(GetAllHotelsQueryResponse expected, GetAllHotelsQueryResponse actual)
        {
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.LocationName, Is.EqualTo(expected.LocationName));
            Assert.That(actual.Latitude, Is.EqualTo(expected.Latitude));
            Assert.That(actual.Longitude, Is.EqualTo(expected.Longitude));

            Assert.That(actual.HotelOfficials, Has.Count.EqualTo(expected.HotelOfficials?.Count ?? 0));

            if (expected.HotelOfficials == null)
            {
                Assert.IsNull(actual.HotelOfficials);
            }
            else
            {
                Assert.That(actual.HotelOfficials, Has.Count.EqualTo(expected.HotelOfficials.Count));

                for (int i = 0; i < expected.HotelOfficials.Count; i++)
                {
                    Assert.That(actual.HotelOfficials[i].Name, Is.EqualTo(expected.HotelOfficials[i].Name));
                }
            }

            Assert.That(actual.Locations, Has.Count.EqualTo(expected.Locations?.Count ?? 0));

            if (expected.Locations == null)
            {
                Assert.IsNull(actual.Locations);
            }
            else
            {
                Assert.That(actual.Locations, Has.Count.EqualTo(expected.Locations.Count));

                for (int i = 0; i < expected.Locations.Count; i++)
                {
                    Assert.That(actual.Locations[i].Name, Is.EqualTo(expected.Locations[i].Name));
                }
            }
        }



        [Test]
        public async Task CreateHotel_ShouldReturnOkResult_WhenHotelCreated()
        {
            // Arrange
            var createHotelRequest = new CreateHotelCommandRequest()
            {
                Name = "Hotel-1",
                LocationName = "Location-1",
                Latitude = 40.7m,
                Longitude = 74.5m,
                HotelOfficials = new List<HotelOfficialCreationRequest>
                {
                    new HotelOfficialCreationRequest { Name = "Mustafa", SurName = "Yener", CorporateTitle = "developer" }
                },
                HotelContacts = new List<HotelContactCreationRequest>
                {
                    new HotelContactCreationRequest { HotelContactType = HotelContactType.PhoneNumber, Content = "9054" }
                },
                LocationIds = new List<int>() { 1, 2 },
            };
          
            mockMediator.Setup(m => m.Send(It.IsAny<CreateHotelCommandRequest>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(Unit.Value);
            // Act
            var result = await controller.CreateHotel(createHotelRequest);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
    }
}
