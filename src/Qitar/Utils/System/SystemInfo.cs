using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Qitar.Utils.System
{
    public class SystemInfo : ISystemInfo
    {
        public string MachineName
        {
            get { return Environment.MachineName; }
        }

        public string OperatingSystem
        {
            get { return GetOperatingSystem(); }
        }

        public string OperatingSystemVersion
        {
            get { return RuntimeInformation.OSDescription; }
        }

        public string MacAddress
        {
            get
            {
                return string.Join(":",
                        NetworkInterface.GetAllNetworkInterfaces()
                            .OrderBy(o => o.Id)
                            .FirstOrDefault(f => f.OperationalStatus == OperationalStatus.Up
                                && !f.Name.Contains("vEthernet")
                                && !f.Description.Contains("Hyper-v"))?
                            .GetPhysicalAddress().GetAddressBytes().Select(s => s.ToString("X2")));
            }
        }

        public int ProcessorCount
        {
            get { return Environment.ProcessorCount; }
        }

        public string Architecture
        {
            get { return RuntimeInformation.OSArchitecture.ToString(); }
        }

        public string ApplicationName
        {
            get
            {
                return AppDomain.CurrentDomain.FriendlyName;
            }
        }

        public static string GetOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return OSPlatform.OSX.ToString();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return OSPlatform.Linux.ToString();
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return OSPlatform.Windows.ToString();
            }

            return "Unknown Operating System";
        }
    }
}
