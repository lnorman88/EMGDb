using EMGDb.Domain.Entities.Media;
using EMGDb.Persistence.EntityConfigurations;
using EMGDb.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMGDb.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<GameEntity> Game => Set<GameEntity>();
    public DbSet<MovieEntity> Movie => Set<MovieEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GameEntityConfiguration());
    }
}
