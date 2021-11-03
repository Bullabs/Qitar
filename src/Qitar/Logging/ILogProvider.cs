using System;
namespace Qitar.Logging
{
    internal interface ILogProvider
    {
        void Log(string filePath, int lineNumber, string member, LogLevel level, string message, Exception exception = null);
    }
}