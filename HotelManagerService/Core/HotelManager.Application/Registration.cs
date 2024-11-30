using FluentValidation;
using HotelManager.Application.Bases;
using HotelManager.Application.Behaviors;
using HotelManager.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
           
            services.AddSingleton<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
           
            services.AddValidatorsFromAssembly(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }


        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types = assembly.GetTypes()
                                .Where(t => t.IsSubclassOf(type) && type != t)
                                .ToList();

            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
