using System;

namespace GitBan.Infrastructure
{
    public static class Logger
    {
         public static void LogException(Exception exception)
         {
             Elmah.ErrorSignal.FromCurrentContext().Raise(exception);
         }

        public static void LogDebugMessage(string message)
        {
            LogException(new DebugException(message));
        }
    }
}