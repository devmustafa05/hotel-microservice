using MassTransit;

namespace HotelManager.Infrastructure.RabbitMQ
{
    public class CommandMessageSenderService<TMessage> : ICommandMessageSenderService<TMessage> where TMessage : class
    {
        private readonly ISendEndpointProvider sendEndpointProvider;

        public CommandMessageSenderService(ISendEndpointProvider sendEndpointProvider)
        {
            this.sendEndpointProvider = sendEndpointProvider;
        }
        public async Task<bool> SendMessageAsync(TMessage message, string queueName)
        {
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send<TMessage>(message);
            return true;
        }
    }
}
