using HotelManager.Application.DTOs.Messaging;
using HotelManager.Infrastructure.RabbitMQ;
using MediatR;

namespace HotelManager.Application.Features.LocationReport.CreateReport
{
    public class CreateReportMessageCommandHandler : IRequestHandler<CreateReportMessageCommandRequest, CreateReportMessageCommandResponse>
    {
        ICommandMessageSenderService<CreateReporMessageCommandDto> commandMessageSenderService;
        public CreateReportMessageCommandHandler(
                ICommandMessageSenderService<CreateReporMessageCommandDto> commandMessageSenderService
            )
        {
            this.commandMessageSenderService = commandMessageSenderService;
        }
        public async Task<CreateReportMessageCommandResponse> Handle(CreateReportMessageCommandRequest request, CancellationToken cancellationToken)
        {

            CreateReporMessageCommandDto messsageCommand = new CreateReporMessageCommandDto()
            {
                LocationId = request.LocationId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
            };
           
            await commandMessageSenderService.SendMessageAsync(messsageCommand, request.QueueName);

            return null;
        }
    }
}
