using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.MessageBroker.RabbitMq.Producers
{
    public class CommandMessageSenderService<TMessage> : ICommandMessageSenderService<TMessage> where TMessage : class 
    {
        private readonly ISendEndpointProvider sendEndpointProvider;

        public CommandMessageSenderService(ISendEndpointProvider sendEndpointProvider)
        {
            this.sendEndpointProvider = sendEndpointProvider;
        }

        public async Task SendMessageAsync(TMessage message, string queueName)
        {   
            var sendEndpoint = await sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send<TMessage>(message);
        }
    }
}
