using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderMicroServic.Application.Interfaces;
using OrderMicroServic.Application.Services;
using OrderMicroService.Domain.Interfaces;
using OrderMicroService.Infrastructure.Context;
using OrderMicroService.Infrastructure.Repositories;
using OrderMicroService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrderMicroService.Infrastructure.Configuration;

public partial class OrderMicroServiceConfiguration
{
	public static void Configure(IServiceCollection services, string dbConnectionString)
	{
		ConfigureDatabase(services, dbConnectionString);
		ConfigureRepositories(services);
		ConfigureServices(services);
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<IOrderService, OrderService>();

		services.AddHttpClient<IProductApiClient, ProductApiClient>(client =>
		{
			client.BaseAddress = new Uri("https://localhost:7182/");
			client.DefaultRequestHeaders.Add("Accept", "application/json");
		});

	}

	private static void ConfigureRepositories(IServiceCollection services)
	{
		services.AddTransient<IOrderRepository, OrderRepository>();
	}

	private static void ConfigureDatabase(IServiceCollection services, string connectionString)
	{
		services.AddDbContext<OrderDBContext>(option =>
		{
			option.UseNpgsql(connectionString,
				b => b.MigrationsAssembly("OrderMicroService.Infrastructure"));
		}, ServiceLifetime.Scoped);
	}
}

public partial class OrderMicroServiceConfiguration
{
	public static bool Migrate(IServiceProvider app)
	{
		try
		{
			var servicesScop = app.CreateScope();
			var services = servicesScop.ServiceProvider;
			var context = services.GetRequiredService<OrderDBContext>();
			context.Database.Migrate();
			servicesScop.Dispose();
			return true;
		}
		catch (Exception ex)
		{
			return false;
		}
	}
}

