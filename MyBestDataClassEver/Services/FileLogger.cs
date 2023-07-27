using System;
using System.IO;
using Microsoft.Extensions.Logging;

public class FileLogger : ILogger {
    public string _filePath { get; set; }
    private readonly object _lock = new object();

    public FileLogger(string filePath) {
       _filePath = filePath;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
        lock (_lock) {
            string logMessage = formatter(state, exception);
            File.AppendAllText(_filePath, $"{DateTime.Now} [{logLevel}] - {logMessage}{Environment.NewLine}");
        }
    }

    public bool IsEnabled(LogLevel logLevel) {
        return true;
    }

    public IDisposable BeginScope<TState>(TState state) {
        return null;
    }
}
