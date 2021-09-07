using System;

namespace Qitar.Tenancy
{
    public class Tenant: IComparable<Tenant>, IEquatable<Tenant>
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

        public int CompareTo(Tenant other)
        {
            return Equals(other)? 1:0;
        }

        public bool Equals(Tenant other)
        {
            if (other == null) return false;
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }
    }

}
