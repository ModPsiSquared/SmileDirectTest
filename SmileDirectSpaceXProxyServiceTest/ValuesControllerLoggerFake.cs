using System;
using System.Collections.Generic;
using System.Text;
using SmileDirect.SpaceXProxyService.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;


namespace SmileDirect.SpaceXProxyServiceTest
{
    class ValuesControllerLoggerFake : ILogger<LaunchPadController>
    {
        public static Exception ProvidedException { get; set; }
        public static string ProvidedMessage { get; set; }
        public static object[] ProvidedArgs { get; set; }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            ProvidedException = ex;
            ProvidedMessage = message;
            ProvidedArgs = args;
        }
    }
}
