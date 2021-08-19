using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.SeriLog
{
    public class LoggerServiceBase
    {
        private ILogger _log;
        private const string LogFolder = @"\LogFiles\";

        [Obsolete]
        public LoggerServiceBase(string name)
        {
            if (name == "DatabaseLogger")
            {
                var builder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                     .Build();
                _log = new LoggerConfiguration()
                    .WriteTo.MSSqlServer(connectionString: builder.GetConnectionString("DefaultConnectionStrings"), tableName: "Logs", autoCreateSqlTable: true).CreateLogger();
            }
            if (name == "FileLogger")
            {
                _log = new LoggerConfiguration()
                    .WriteTo.File(string.Format("{0}{1}", Directory.GetCurrentDirectory() + LogFolder, ".txt"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                    .CreateLogger();
            }
        }

        public void Verbose(string message) => _log.Verbose(message);
        public void Verbose<T>(string message, T t) => _log.Verbose(message, t);
        public void Fatal(string message) => _log.Fatal(message);
        public void Fatal<T>(string message, T t) => _log.Fatal(message, t);
        public void Information(string message) => _log.Information(message);
        public void Information<T>(string message, T t) => _log.Information(message, t);
        public void Information(string message, params object[] propertyValues) => _log.Information(message, propertyValues);
        public void Information(string message, Exception exception, params object[] propertyValues) => _log.Information(exception, message, propertyValues);
        public void Warning(string message) => _log.Warning(message);
        public void Warning<T>(string message, T t) => _log.Warning(message, t);
        public void Debug(string message) => _log.Debug(message);
        public void Debug<T>(string message, T t) => _log.Debug(message, t);
        public void Error(string message) => _log.Error(message);
        public void Error<T>(string message, T t) => _log.Error(message, t);
        public void Error(string message, Exception exception, params object[] propertyValues) => _log.Error(exception, message, propertyValues);
    }
}
