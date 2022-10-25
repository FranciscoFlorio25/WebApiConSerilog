using MyApp.Api.Routes;
using MyApp.Application;
using MyApp.Infrastructure;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    //.ReadFrom.Configuration(builder.Configuration)
    //.WriteTo.Console()
    .WriteTo.File(new JsonFormatter(renderMessage: true),"../logs/log.json",rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMyAppInfrastructure(builder.Configuration);

builder.Services.AddMyAppApplication(); //Metodo de extencion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProducts();

app.Run();

