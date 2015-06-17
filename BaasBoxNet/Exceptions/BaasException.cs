using System;

namespace BaasBoxNet.Exceptions
{
    /// <summary>
    ///     Base class for all the exceptions thrown by the BaasBox .Net SDK
    /// </summary>
    public class BaasException : Exception
    {
        public BaasException()
        {
        }

        public BaasException(string message) : base(message)
        {
        }

        public BaasException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}