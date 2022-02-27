using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Web.WebClient
{
    public interface IWebClientInfoProvider
    {
        string BrowserInfo { get; }

        string IpAddress { get; }
    }
}
