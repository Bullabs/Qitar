using Qitar.Entities;
using Qitar.Store.Connections;

namespace Qitar.Store.Entities
{
    public class TenantEntity : Entity
    {
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string ConnectionString { get; set; }
        public ConnectionType ConnectionType {  get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }
    }
}
