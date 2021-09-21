using Microsoft.AspNetCore.Http;
using Qitar.Tenancy;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy.Strategies
{
    public class HeaderStrategy : ITenantStrategy
    {
        private readonly string _headerKey;

        public HeaderStrategy(string headerKey)
        {
            _headerKey = headerKey;
        }

        public ValueTask<string> GetIdentifier(object context, CancellationToken cancellationToken = default)
        {
            if (!(context is HttpContext httpContext))
            {
                throw new TenancyException(this.GetType().Name, 
                    new ArgumentException($"\"{nameof(context)}\" type must be of type HttpContext", nameof(context)));
            }

            return new ValueTask<string>(httpContext?.Request.Headers[_headerKey]);
        }
    }
}
