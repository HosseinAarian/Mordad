//https://localhost:7182/swagger/index.html
//http://localhost:5000/swagger/index.html
using Microsoft.EntityFrameworkCore;
using ProductMicroService.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ProductMicroServiceConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("ProductMicroServiceConnection"));

builder.Services.AddOpenApi();

var app = builder.Build();
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

