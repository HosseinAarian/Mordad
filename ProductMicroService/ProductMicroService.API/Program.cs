//https://localhost:7182/swagger/index.html
//http://localhost:5000/swagger/index.html
using Microsoft.EntityFrameworkCore;
using ProductMicroService.Infrastructure.Configuration;
using ProductMicroService.Utilities.ExternalApiServicces;
using ProductMicroService.Utilities.MiddleWares;
using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Information()
	.WriteTo.Console()
	.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddHttpClient<ExternalApiService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ProductMicroServiceConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("ProductMicroServiceConnection"));

builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
ProductMicroServiceConfiguration.Migrate(app.Services);

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
	app.UseHttpsRedirection();
}
app.MapControllers();
app.Run();

