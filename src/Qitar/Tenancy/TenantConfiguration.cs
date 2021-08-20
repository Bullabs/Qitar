using Qitar.Entities;
using System;

namespace Qitar.Tenancy
{
    public class TenantConfiguration : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionStrings { get; set; }
    }
}
