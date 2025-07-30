using Microsoft.EntityFrameworkCore;
using OrderMicroService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroService.Infrastructure.Context;

public class OrderDBContext : DbContext
{
	public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options) { }
	public DbSet<Order> Orders => Set<Order>();
}

