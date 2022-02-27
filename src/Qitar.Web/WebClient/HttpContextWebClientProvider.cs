using Microsoft.AspNetCore.Http;
using Qitar.Logging;
using Qitar.Utils;
using System;

namespace Qitar.Web.WebClient
{
    public class HttpContextWebClientProvider : IWebClientInfoProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger _logger;

        public HttpContextWebClientProvider(IHttpContextAccessor httpContextAccessor, ILogger logger)
        {
            _httpContextAccessor = httpContextAccessor.NotNull();
            _logger = logger.NotNull();
        }

        public string BrowserInfo => _httpContextAccessor.HttpContext?.Request?.Headers?["User-Agent"];

        public string IpAddress => null;

        private string GetIp(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

            }
            catch(Exception ex)
            {
                _logger.Warning(ex.Message);
                return null;
            }
        }

    }
}
