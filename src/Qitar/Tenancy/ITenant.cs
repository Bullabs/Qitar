using System;

namespace Qitar.Tenancy
{
    public interface ITenant
    {
        public Guid? Id {  get;}
        public string Identifier { get; }
        public string Name { get; }
        public string ConnectionString { get; }
        public int ConnectionType { get; }
        public string Culture { get; }
        public string TimeZone { get; }
    }
}
