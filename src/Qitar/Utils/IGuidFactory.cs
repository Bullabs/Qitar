using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Utils
{
    internal interface IGuidFactory
    {
        Guid Create();
        Guid Create(Guid SouriceId);
    }
}
