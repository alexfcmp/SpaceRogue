using System;

namespace Services
{
    public sealed class ServiceInitializationException : Exception
    {
        public ServiceInitializationException(string message) : base(message)
        {
        }
    }
}