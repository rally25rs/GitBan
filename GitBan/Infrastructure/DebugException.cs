using System;

namespace GitBan.Infrastructure
{
    public class DebugException : Exception
    {
        public DebugException(string message) : base(message)
        {
        }
    }
}