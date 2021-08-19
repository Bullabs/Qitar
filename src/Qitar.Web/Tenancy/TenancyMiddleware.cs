using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Qitar.Web.Tenancy
{
    public class TenancyMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
