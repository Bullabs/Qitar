using System;
using System.Collections.Generic;

namespace Qitar.Tenancy
{
    public class TenantInfo: ITenantInfo, IComparable<TenantInfo>, IEquatable<TenantInfo>, IEqualityComparer<TenantInfo>
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }

        public override string ToString()
        {
            return $"[{Name} : {Id}]";
        }

        public int CompareTo(TenantInfo other)
        {
            return Equals(other)? 1:0;
        }

        public bool Equals(TenantInfo other)
        {
            if (other == null) return false;
            return ReferenceEquals(this, other) || Id.Equals(other.Id);
        }

        public bool Equals(TenantInfo x, TenantInfo y)
        {
            return ReferenceEquals(x, y) || x.Id.Equals(y.Id);
        }

        public int GetHashCode(TenantInfo obj)
        {
            return obj.Id.GetHashCode() ^ 31;
        }
    }
}
