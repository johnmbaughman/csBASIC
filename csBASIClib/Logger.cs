using System;
using Serilog;
using Serilog.Events;

namespace csBASIClib
{
    public class Logger
    {
        private readonly string _fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public Logger(string fileName)
        {
            _fileName = fileName;
            InitializeLog();
        }

        /// <summary>
        /// Initializes the log.
        /// </summary>
        private void InitializeLog()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(_fileName)
                .CreateLogger();
        }

        /// <summary>
        /// Writes to log.
        /// </summary>
        /// <param name="eventLevel">The event level.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void WriteToLog(LogEventLevel eventLevel, string message, Exception exception = null)
        {
            switch (eventLevel)
            {
                case LogEventLevel.Debug:
                    break;
                case LogEventLevel.Error:
                    break;
                case LogEventLevel.Fatal:
                    break;
                case LogEventLevel.Information:
                    break;
                case LogEventLevel.Verbose:
                    break;
                case LogEventLevel.Warning:
                    break;
            }
        }
    }
}