//using Convey.Persistence.EFCore.Postgres.Builder;
//using Microsoft.Extensions.DependencyInjection;

//namespace Convey.Persistence.EFCore.Postgres;

//public static class Extensions
//{
//    private const string SectionName = "postgres";
//    private const string RegistryName = "persistence.postgres";

//    public static IConveyBuilder AddPostgresDbContext(this IConveyBuilder builder, string sectionName = SectionName)
//    {
//        if (string.IsNullOrWhiteSpace(sectionName))
//        {
//            sectionName = SectionName;
//        }

//        var options = builder.GetOptions<PostgresOptions>(sectionName);
//        return builder.AddPostgresDbContext(options);
//    }

//    public static IConveyBuilder AddPostgresDbContext(this IConveyBuilder builder,
//        Func<IPostgresOptionsBuilder, IPostgresOptionsBuilder> buildOptions)
//    {
//        var options = buildOptions(new PostgresOptionsBuilder()).Build();
//        return builder.AddPostgresDbContext(options);
//    }

//    public static IConveyBuilder AddPostgresDbContext(this IConveyBuilder builder, PostgresOptions options)
//    {
//        if (!builder.TryRegister(RegistryName))
//        {
//            return builder;
//        }

//        builder.Services
//            .AddSingleton(options)
//            .AddDbContext(opt =>
//            {
//                opt.UseNpgsql(options.ConnectionString);
//            });
//        return builder;
//    }
//}
