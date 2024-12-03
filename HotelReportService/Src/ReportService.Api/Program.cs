using ReportService.Persistence;
using ReportService.Application;
using MassTransit;
using ReportService.Api.Consumers;
using ReportService.Application.ExternalServices;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var evn = builder.Environment;

builder.Configuration.SetBasePath(evn.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{evn.EnvironmentName}.json", optional: true);


builder.Services.AddSingleton<CreateReporMessageCommandConsumer>();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateReporMessageCommandConsumer>();
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
            e.Consumer<CreateReporMessageCommandConsumer>(context); 
        });
    });
});


builder.Services.AddMassTransitHostedService();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);


//builder.Services.AddTransient<IExternalApiService, ExternalApiService>();
//builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>(client =>
//{
//    var hotelMicroServisBaseUrl = builder.Configuration["HotelMicroServis:BaseUrl"];
//    hotelMicroServisBaseUrl = string.IsNullOrWhiteSpace(hotelMicroServisBaseUrl) ? "http://localhost:5001" : hotelMicroServisBaseUrl;
//    client.BaseAddress = new Uri(hotelMicroServisBaseUrl);
//    client.DefaultRequestHeaders.Add("Authorization", "Bearer your_token"); 
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
