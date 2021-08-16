using Microsoft.EntityFrameworkCore;

namespace Qitar.Store.EntityFramework
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options): base(options)
        {
           
        }
    }
}
