using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.ExternalServices;
using ReportService.Application.MessageBroker.RabbitMq.Producers;
using ReportService.Application.Services.ReportService;

namespace ReportService.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddScoped<IReportService, ReportService.Application.Services.ReportService.ReportService>();
            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped(typeof(ICommandMessageSenderService<>), typeof(CommandMessageSenderService<>));

            services.AddTransient<IExternalApiService, ExternalApiService>();
            services.AddHttpClient<IExternalApiService, ExternalApiService>(client =>
            {
                var hotelMicroServisBaseUrl = configuration["HotelMicroServis:BaseUrl"];
                hotelMicroServisBaseUrl = string.IsNullOrWhiteSpace(hotelMicroServisBaseUrl) ? "http://localhost:5001" : hotelMicroServisBaseUrl;
                client.BaseAddress = new Uri(hotelMicroServisBaseUrl);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer your_token");
            });
        }
    }
}
