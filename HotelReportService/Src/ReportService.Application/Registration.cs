using Microsoft.Extensions.DependencyInjection;
using ReportService.Application.ExternalServices;
using ReportService.Application.MessageBroker.RabbitMq.Producers;
using ReportService.Application.Services.ReportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {  
            services.AddScoped<IReportService, ReportService.Application.Services.ReportService.ReportService>();
           // services.AddScoped<ICommandMessageSenderService, CommandMessageSenderService>();
            services.AddScoped(typeof(ICommandMessageSenderService<>), typeof(CommandMessageSenderService<>));
            services.AddTransient<IExternalApiService, ExternalApiService>();
            services.AddTransient<IExternalApiService, ExternalApiService>();

            //services.AddHttpClient<IExternalApiService, ExternalApiService>(client =>
            //{
            //    client.BaseAddress = new Uri("https://api.example.com/");
            //    client.DefaultRequestHeaders.Add("Authorization", "Bearer your_token"); // Gerekirse özel header ekleyin.
            //});
        }
    }
}
