using HotelManagerService.IntegrationTest.Helper;
using System.Net;
using System.Net.NetworkInformation;

namespace HotelManagerService.IntegrationTest.Helper
{
    [TestFixture]
    public class APITest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test_GetRequest()
        {
            HttpClientHelper httpClientHelper = new HttpClientHelper();

            // Arrange
            var endpoint = "/api/hotel/getallhotels";

            var response = await httpClientHelper.GetAsync(endpoint);

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // Add more assertions as needed
        }
    }
}

  