using EMGDb.Application.CQRS.Game.CreateGame;
using EMGDb.Domain.Options;
using EMGDb.Persistence;
using EMGDb.Persistence.Interfaces;
using EMGDb.Persistence.Repositorys;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EMGDb.WebApi.Helpers;

public static class ServiceCollectionExtensions
{
    public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.Name));
    }
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateGameQuery).Assembly);
    }

    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGameRepository, GameReposiroty>();
        services.AddScoped<IMovieRepository, MovieRepository>();
    }

    public static void AddDatabase(this IServiceCollection service, IConfiguration configuration)
    {
        var dbOptions = configuration.GetSection(DatabaseOptions.Name).Get<DatabaseOptions>();
        service.AddDbContext<ApplicationDbContext>(x => x.UseSqlite(dbOptions.ConnectionString));

        service.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    }
}
