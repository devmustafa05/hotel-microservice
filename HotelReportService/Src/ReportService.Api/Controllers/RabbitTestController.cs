using Microsoft.AspNetCore.Mvc;
using MassTransit;
using ReportService.Api.Message;
using ReportService.Application.MessageBroker.RabbitMq.Producers;
using MassTransit.Transports;
using ReportService.Application.ExternalServices;
using Microsoft.Extensions.Configuration;

namespace ReportService.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RabbitTestController : ControllerBase
    {
        private readonly ISendEndpointProvider sendEndpointProvider;
        private readonly IExternalApiService externalApiService;
        private readonly IConfiguration configuration;

        private readonly ICommandMessageSenderService<CreateReporMessageCommand> messageSenderService;
        public RabbitTestController(ISendEndpointProvider sendEndpointProvider,
            ICommandMessageSenderService<CreateReporMessageCommand> messageSenderService,
            IExternalApiService externalApiService,
            IConfiguration configuration
            )
        {
            this.sendEndpointProvider = sendEndpointProvider;
            this.messageSenderService = messageSenderService;
            this.externalApiService = externalApiService;
            this.configuration = configuration;
        }

        public async Task<string>  test()
        {
            try
            {
                var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri("queue:report-servis"));

                var ss = sendEndpoint.GetType().FullName;

                var createOrderServisMessageCommand = new CreateReporMessageCommand();

                createOrderServisMessageCommand.Name = "TestDeneme";
                createOrderServisMessageCommand.Latitude = 25;
                createOrderServisMessageCommand.Longitude = 648;

                var reportServisQueue = configuration["RabbitMQ:Queues:ReportServis"];
                await messageSenderService.SendMessageAsync(createOrderServisMessageCommand, reportServisQueue);

               // await sendEndpoint.Send<CreateReporMessageCommand>(createOrderServisMessageCommand);

            }
            catch (Exception ex)
            {
                var ssas = ex;
                throw;
            }
            return "asdasd";
        }

        public async Task<string> test22()
        {
            try
            {

                var locationUrl = configuration["HotelMicroServis:Locations"];
                locationUrl = string.IsNullOrWhiteSpace(locationUrl) ? "/locations" : locationUrl;

                var ss = await externalApiService.GetDataAsync(locationUrl);
                var asdas = ss;

                return ss;

            }
            catch (Exception ex)
            {
                var ssas = ex;
                throw;
            }




            return "asdasd";
        }
    }
}
