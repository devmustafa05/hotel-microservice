using MassTransit.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.MessageBroker.RabbitMq.Producers
{
    public interface ICommandMessageSenderService<TMessage>
    {   Task SendMessageAsync(TMessage message, string queueName);
       
    }
}
