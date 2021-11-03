using Qitar.Utils;
using System;
using System.Runtime.CompilerServices;

namespace Qitar.Logging
{
    internal class Logger : ILogger
    {
        private readonly ILogProvider _logProvider;

        public Logger(ILogProvider logProvider)
        {
            _logProvider = logProvider.NotNull();
        }
        public void Critical(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Critical, message);
        }

        public void Critical(Exception exception, string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Critical, message, exception);
        }

        public void Debug(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Debug, message);
        }

        public void Error(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Error, message);
        }

        public void Error(Exception exception, string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Error, message,exception);
        }

        public void Information(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Info, message);
        }

        public void Trace(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Trace, message);
        }

        public void Warning(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "")
        {
            _logProvider.Log(filePath, lineNumber, member, LogLevel.Warning, message);
        }
    }
}
