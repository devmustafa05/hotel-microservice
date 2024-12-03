using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Infrastructure.RabbitMQ
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public interface ICommandMessageSenderService<TMessage> where TMessage : class
    {
        Task<bool> SendMessageAsync(TMessage message, string queueName);
    }
}
