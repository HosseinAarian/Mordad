using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductMicroService.Application.Interfaces;
using ProductMicroService.Application.Services;
using ProductMicroService.Domain.Interfaces;
using ProductMicroService.Infrastructure.Context;
using ProductMicroService.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ProductMicroService.Infrastructure.Configuration;

public partial class ProductMicroServiceConfiguration
{
	public static void Configure(IServiceCollection services, string dbConnectionString)
	{
		ConfigureDatabase(services, dbConnectionString);
		ConfigureRepositories(services);
		ConfigureServices(services);
	}

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddTransient<IProductService, ProductService>();
	}

	private static void ConfigureRepositories(IServiceCollection services)
	{
		services.AddTransient<IProductRepository, ProductRepository>();
	}

	private static void ConfigureDatabase(IServiceCollection services, string connectionString)
	{
		services.AddDbContext<ProductDBContext>(option =>
		{
			option.UseNpgsql(connectionString,
				b => b.MigrationsAssembly("ProductMicroService.Infrastructure"));
		}, ServiceLifetime.Scoped);
	}
}

public partial class ProductMicroServiceConfiguration
{
	public static bool Migrate(IServiceProvider app)
	{
		try
		{
			var servicesScop = app.CreateScope();
			var services = servicesScop.ServiceProvider;
			var context = services.GetRequiredService<ProductDBContext>();
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

