
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Hotel API",
        Version = "v1"
    });
});


// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.RouteTemplate = "swagger/v1/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel API V1");
    });

    app.MapGet("/swagger/v1/swagger.json", async context =>
    {
        var swaggerJson = System.IO.File.ReadAllText("swagger/v1/swagger.json");
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(swaggerJson);
    });
}

app.UseAuthorization();

app.MapControllers();
app.Run();
