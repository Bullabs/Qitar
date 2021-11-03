using System;
using System.Runtime.CompilerServices;

namespace Qitar.Logging
{
    public interface ILogger
    {
        void Trace(string message,[CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0,[CallerMemberName] string member = "");
        void Debug(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Information(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Warning(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Critical(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Critical(Exception exception, string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Error(string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
        void Error(Exception exception, string message, [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string member = "");
    }
}