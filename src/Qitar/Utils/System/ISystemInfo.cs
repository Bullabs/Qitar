using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Utils.System
{
    public interface ISystemInfo
    {
        string ApplicationName { get; }
        string MacAddress { get; }
        string MachineName { get; }
        string OperatingSystem { get; }
        string OperatingSystemVersion { get; }
        string Architecture { get; }
        int ProcessorCount { get; }
    }
}
