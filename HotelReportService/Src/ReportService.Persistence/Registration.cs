using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using ReportService.Persistence.Context;
using ReportService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<MongoDbContext>(sp =>
            {
                var databaseName = configuration.GetConnectionString("MongoDbDatabaseName");
                var connectionString = configuration.GetConnectionString("MongoDbConnectionString");

                if (databaseName is null)
                {
                    databaseName = "YourDatabaseName";
                }

                var mongoClient = new MongoClient(connectionString);
                return new MongoDbContext(mongoClient, databaseName);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
