using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Security
{
    public interface IClaimsAccessor
    {
        IUser CurrentUser { get;}
    }
}
