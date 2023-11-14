using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using StringCalculator;
using StringCalculator.Persistance;
using StringCalculatorAPI;
using StringCalculatorAPI.Controllers;
using System.IO;
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
builder.Services.AddHealthChecks().AddCheck("HistoryCheck",new HistoryHealthCheck(config));
var app = builder.Build();

var path = config["Path"];
var folder = Path.GetDirectoryName(path);

if (!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
    File.Create(path).Close();
}
else
{
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health.json", new HealthCheckOptions
{
    ResponseWriter = HistoryHealthCheck.writeJson
});

app.Run();
