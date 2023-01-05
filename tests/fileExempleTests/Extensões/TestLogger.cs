using System;
using Microsoft.Extensions.Logging;
using Moq;

namespace fileExempleTests.Extensões
{
    public static class TestLogger
    {
        public static void SetupErrorWithAnyMessage<T>(this Mock<ILogger<T>> logger, Exception exception)
        {
            SetupLogWithAnyMessage(logger, LogLevel.Error, exception);
        }

        public static void SetupErrorLog<T>(this Mock<ILogger<T>> logger, string message, Exception exception)
        {
            SetupLog(logger, LogLevel.Error, message, exception);
        }

        public static void SetupErrorLog<T>(this Mock<ILogger<T>> logger, string message)
        {
            SetupLog(logger, LogLevel.Error, message);
        }
        
        public static void SetupLogWithAnyMessage<T>(this Mock<ILogger<T>> logger, LogLevel logLevel, Exception exception = null)
        {
            logger.Setup(x => x.Log(logLevel, 
                                    It.IsAny<EventId>(),
                                    It.IsAny<object>(),
                                    exception,
                                    (Func<object, Exception, string>)It.IsAny<object>()));
        }

        public static void SetupLog<T>(this Mock<ILogger<T>> logger, LogLevel logLevel, string message = null, Exception exception = null)
        {
            logger.Setup(x => x.Log(logLevel, 
                                    It.IsAny<EventId>(),
                                    It.Is<object>(v => v.ToString().Equals(message)),
                                    exception,
                                    (Func<object, Exception, string>)It.IsAny<object>()));
        }
    }
}