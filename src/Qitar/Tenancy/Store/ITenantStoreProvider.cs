﻿using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Tenancy.Store
{
    public interface ITenantStoreProvider
    {
        ValueTask<TenantConfiguration> GetById(object id, CancellationToken cancellationToken = default);
    }
}