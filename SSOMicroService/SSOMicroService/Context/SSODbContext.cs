using Microsoft.EntityFrameworkCore;
using SSOMicroService.Models.Users;

namespace SSOMicroService.Context;

public class SSODbContext : DbContext
{
	public SSODbContext(DbContextOptions<SSODbContext> options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
}
