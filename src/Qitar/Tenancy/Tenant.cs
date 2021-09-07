using System;

namespace Qitar.Tenancy
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }

        public override string ToString()
        {
            return $"[{Name} : {Id}]";
        }
        public static bool operator ==(Tenant left, Tenant right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tenant left, Tenant right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not Tenant tenant) return false;

            return ReferenceEquals(this, tenant) || Id.Equals(tenant.Id);
        }
    }

}
