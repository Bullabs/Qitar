using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Migrations
{
    public interface IDatabaseMigrator
    {
        ValueTask MigrateDatabase(Assembly assembly, string connectionStringName, CancellationToken cancellationToken = default);
    }
}
