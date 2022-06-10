using CoronaApp.Api.Dal;
using CoronaApp.Services.Models;
using CoronaApp.Api.Dal.Repositories;
using CoronaApp.Services.Interface;
using Serilog;
using Serilog.Sinks.File;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<DB>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
var app = builder.Build();
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseExceptionHandler(c => c.Run(async contxt =>
{
    var code = contxt.Response.StatusCode > 400 ? 400 : 200;
    var exeption = contxt.Features
    .Get<IExceptionHandlerPathFeature>().Error;
    var response = new { error = exeption.Message, code = code };
    await contxt.Response.WriteAsJsonAsync(response);
}));
app.Run();
