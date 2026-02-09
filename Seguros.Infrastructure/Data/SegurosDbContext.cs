using Microsoft.EntityFrameworkCore;

namespace Seguros.Infrastructure.Data;

public class SegurosDbContext : DbContext
{
    public SegurosDbContext(DbContextOptions<SegurosDbContext> options) : base(options) { }

    public DbSet<SeguroEntity> Seguros => Set<SeguroEntity>();
}
