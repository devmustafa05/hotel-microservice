using HotelManager.Persistence;
using HotelManager.Application;
using HotelManager.Mapper;
using HotelManager.Application.Exceptions;
using MassTransit;
using HotelManager.Infrastructure;
using HotelManager.Api;
using GreenPipes;
using HotelManager.Application.Features.LocationReport.CreateReport;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
configureLogging();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var evn = builder.Environment;

builder.Configuration.SetBasePath(evn.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{evn.EnvironmentName}.json", optional: true);


builder.Services.AddTransient<CreateReportMessageConsumer>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateReportMessageConsumer>(context =>
    {

    });

    x.UsingRabbitMq((context, cfg) =>
    {
        var rabbitMqHost = builder.Configuration["RabbitMQ:Host"];
        var rabbitMqUsername = builder.Configuration["RabbitMQ:Username"];
        var rabbitMqPassword = builder.Configuration["RabbitMQ:Password"];

        var reportServisQueue = builder.Configuration["RabbitMQ:Queues:ReportServis"];

        cfg.Host(rabbitMqHost, h =>
        {
            h.Username(rabbitMqUsername);
            h.Password(rabbitMqPassword);
        });

        cfg.ReceiveEndpoint(reportServisQueue, e =>
        {
            // e.Consumer<CreateReporMessageCommandConsumer>();
            e.Consumer<CreateReportMessageConsumer>(context);
        });
    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();
app.MapControllers();
app.Run();


void configureLogging()
{
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{environment}.json", optional: true
            ).Build();

         Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration) 
        .CreateLogger();
}