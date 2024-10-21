using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using Microsoft.Data.SqlClient;
using BookManagementSys.Service;
using BookManagementSys.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json or any other source
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register IDbConnection as a transient service with SqlConnection
builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(connectionString));

// Add services from different layers
builder.Services.AddServiceLayer();  // For service layer
builder.Services.AddDataLayer();     // For data layer


// Other services like controllers, Swagger, etc.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");



app.Run();

// public record WeatherForecast(DateOnly Date, int TemperatureC, string Summary);
