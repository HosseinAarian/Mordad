using Microsoft.EntityFrameworkCore;
using ProductMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroService.Infrastructure.Context;
public class ProductDBContext : DbContext
{
	public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

	public DbSet<Product> Products => Set<Product>();
}

