namespace Convey.Persistence.EFCore
{
    public interface IDataSeeder
    {
        Task SeedAllAsync();
    }
}
