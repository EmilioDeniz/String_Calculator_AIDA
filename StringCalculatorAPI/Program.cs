using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using StringCalculator;
using StringCalculator.Persistance;
using StringCalculatorAPI;
using StringCalculatorAPI.Controllers;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
var config = builder.Configuration.SetBasePath(Environment.CurrentDirectory)
    .AddJsonFile("appsettings.json",true,false)
    .AddJsonFile("appsettings.Development.json")
    .Build();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DatePicker,APIDatePicker>();
builder.Services.AddScoped<Save,HistoryStorer>(services => new HistoryStorer(config["Path"]));
builder.Services.AddScoped<HistoryHandler,HistoryHandler>(services => new HistoryHandler(new HistoryStorer(config["Path"]),services.GetRequiredService<DatePicker>()));
builder.Services.AddHealthChecks().AddCheck("HistoryCheck",new HistoryHealthCheck(config["Path"]));
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

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HistoryHealthCheck.writeJson
});

app.Run();
