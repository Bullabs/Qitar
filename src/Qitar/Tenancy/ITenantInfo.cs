using Qitar.Entities;

namespace Qitar.Tenancy
{
    public interface ITenantInfo : IEntity
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }
    }
}
