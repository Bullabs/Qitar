using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Qitar.Dispatcher;

namespace Qitar.Web.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IDispatcher _dispatcher;
        public BaseController()
        {
            _dispatcher ??= HttpContext.RequestServices.GetService<IDispatcher>();
        }
    }
}