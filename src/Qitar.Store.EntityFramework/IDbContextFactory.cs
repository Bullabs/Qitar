
namespace Qitar.Store.EntityFramework
{
    public interface IDbContextFactory
    {
        RepositoryDbContext CreateDbContext();
    }
}
