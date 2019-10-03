namespace MichalBialecki.com.TicketStore.Console.Logging
{
    using System.Collections.Concurrent;
    using System.IO;
    using Microsoft.Extensions.Logging;

    public class Log4NetProvider : ILoggerProvider
    {
        private readonly string _log4NetConfigFile;

        private readonly bool _skipDiagnosticLogs;

        private readonly ConcurrentDictionary<string, ILogger> _loggers =
            new ConcurrentDictionary<string, ILogger>();

        public Log4NetProvider(string log4NetConfigFile, bool skipDiagnosticLogs)
        {
            _log4NetConfigFile = log4NetConfigFile;
            _skipDiagnosticLogs = skipDiagnosticLogs;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
        }

        public void Dispose()
        {
            _loggers.Clear();
        }

        private ILogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name, new FileInfo(_log4NetConfigFile), _skipDiagnosticLogs);
        }
    }
}
