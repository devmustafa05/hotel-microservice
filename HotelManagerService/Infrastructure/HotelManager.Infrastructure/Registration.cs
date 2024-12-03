using HotelManager.Infrastructure.RabbitMQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelManager.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {   
            services.AddScoped(typeof(ICommandMessageSenderService<>), typeof(CommandMessageSenderService<>));
        }
    }
}
