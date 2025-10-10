using BNPL.Application.Features.Proformas.Commands.CreateProforma;
using BNPL.Infrastructure.Repository.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

BNPLConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("BNPLConnection"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProformaCommandHandler).Assembly));


var app = builder.Build();

BNPLConfiguration.Migrate(app.Services);

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
