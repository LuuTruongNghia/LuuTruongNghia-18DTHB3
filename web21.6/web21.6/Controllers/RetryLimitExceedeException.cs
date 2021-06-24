using System;
using System.Runtime.Serialization;

namespace web21._6.Controllers
{
    [Serializable]
    internal class RetryLimitExceedeException : Exception
    {
        public RetryLimitExceedeException()
        {
        }

        public RetryLimitExceedeException(string message) : base(message)
        {
        }

        public RetryLimitExceedeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RetryLimitExceedeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}