using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class NoSuchStrategyException : Exception
    {
        public NoSuchStrategyException() { }

        public NoSuchStrategyException(string message) : base(message) { }

        public NoSuchStrategyException(string message, Exception innerException) : base(message, innerException) { }

        protected NoSuchStrategyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
