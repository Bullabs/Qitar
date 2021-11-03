using Microsoft.Extensions.Logging;
using Qitar.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Qitar.Logging
{
    public class LogProvider : ILogProvider
    {
        private readonly ILoggerFactory _loggerFactory;
        private Dictionary<string, Microsoft.Extensions.Logging.ILogger> _loggers = new Dictionary<string, Microsoft.Extensions.Logging.ILogger>();

        public LogProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory.NotNull();
        }

        public void Log(string filePath, int lineNumber, string member, LogLevel level, string message, Exception exception = null)
        {
            var loggerKey = Path.GetFileNameWithoutExtension(filePath);
            var logger  =_loggers.GetValueOrDefault(loggerKey);

            if (!_loggers.ContainsKey(loggerKey))
            {
                logger = _loggerFactory.CreateLogger(loggerKey);
                _loggers[loggerKey] = logger;
            }

            message = $"[{member}({lineNumber})]-{message}";

            switch (level)
            {
                case LogLevel.Trace: logger.LogTrace(message); break;
                case LogLevel.Debug: logger.LogDebug(message); break;
                case LogLevel.Info: logger.LogInformation(message); break;
                case LogLevel.Warning: logger.LogWarning(message); break;
                case LogLevel.Critical: logger.LogCritical(0, exception, message); break;
                case LogLevel.Error: logger.LogError(0, exception, message); break;
            }
        }
    }
}