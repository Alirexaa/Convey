namespace Convey.Persistence.EFCore.Postgres;

public class PostgresOptions
{
    public string ConnectionString { get; set; }
    public string InMemoryDatabaseName { get; set; }
    public bool UseInMemoryDatabase { get; set; }
}