using EMGDb.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;

namespace EMGDb.Persistence.Interfaces;
public interface IApplicationDbContext
{
    DbSet<GameEntity> Game { get; }
    DbSet<MovieEntity> Movie { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);    
}