using BNPL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BNPL.Infrastructure.Repository.Context;

public class BNPLDBContext : DbContext
{
    public BNPLDBContext(DbContextOptions<BNPLDBContext> options) : base(options) { }

    public DbSet<Proforma> Proformas { get; set; }
    public DbSet<ProformaDetail> ProformaDetails { get; set; }
}
