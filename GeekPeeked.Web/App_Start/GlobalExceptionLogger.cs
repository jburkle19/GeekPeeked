using System;
using System.Web.Http.ExceptionHandling;

namespace GeekPeeked.Web.App_Start
{
    public class GlobalExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            // TODO
        }

        public static void LogError(string message, Exception ex)
        {
            // TODO
        }
    }
}