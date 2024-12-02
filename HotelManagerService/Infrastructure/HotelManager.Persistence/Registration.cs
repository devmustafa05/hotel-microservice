using HotelManager.Application.Interfaces.Repositories;
using HotelManager.Application.Interfaces.UnitOfWorks;
using HotelManager.Persistence.Context;
using HotelManager.Persistence.Repositories;
using HotelManager.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {  
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DefaultConnectionStrings")));

            // Lazy Loading
            //services.AddDbContext<AppDbContext>(opt =>
            // opt.UseLazyLoadingProxies() 
            // .UseNpgsql(configuration.GetConnectionString("DefaultConnectionStrings")));
          
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRespostory<>));
            services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
           
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
