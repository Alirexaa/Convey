using Convey.Persistence.EFCore.Postgres.Builder;
using Convey.Persistence.EFCore.Postgres.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Convey.Persistence.EFCore.Postgres;

public static class Extensions
{
    private const string SectionName = "postgres";
    private const string RegistryName = "persistence.postgres";

    public static IConveyBuilder AddPostgresDbContext<TApplicationDbContext>(this IConveyBuilder builder, string sectionName = SectionName) where TApplicationDbContext : DbContext
    {
        if (string.IsNullOrWhiteSpace(sectionName))
        {
            sectionName = SectionName;
        }

        var options = builder.GetOptions<PostgresOptions>(sectionName);
        return builder.AddPostgresDbContext<TApplicationDbContext>(options);
    }

    public static IConveyBuilder AddPostgresDbContext<TApplicationDbContext>(this IConveyBuilder builder,
        Func<IPostgresOptionsBuilder, IPostgresOptionsBuilder> buildOptions) where TApplicationDbContext : DbContext
    {
        var options = buildOptions(new PostgresOptionsBuilder()).Build();
        return builder.AddPostgresDbContext<TApplicationDbContext>(options);
    }

    public static IConveyBuilder AddPostgresDbContext<TApplicationDbContext>(this IConveyBuilder builder, PostgresOptions options) where TApplicationDbContext : DbContext
    {
        if (!builder.TryRegister(RegistryName))
        {
            return builder;
        }

        builder.Services
            .AddSingleton(options)
            .AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWorkEf<>))
            .AddScoped(typeof(IRepository<>),typeof(Repository<,>))
            .AddDbContext<TApplicationDbContext>(opt =>
            {
                if (options.UseInMemoryDatabase)
                {
                    opt.UseInMemoryDatabase(options.InMemoryDatabaseName);
                }
                else
                {
                    opt.UseNpgsql(options.ConnectionString);
                }
            });
        return builder;
    }
}
