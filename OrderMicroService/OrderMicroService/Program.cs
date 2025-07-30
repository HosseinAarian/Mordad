//https://localhost:7077/swagger/index.html
using Microsoft.EntityFrameworkCore;
using OrderMicroService.Infrastructure.Configuration; ;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

OrderMicroServiceConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("OrderMicroServiceConnection"));

builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

OrderMicroServiceConfiguration.Migrate(app.Services);

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
