using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class InvallidMoveException : Exception
    {
        public InvallidMoveException() : base() { }

        public InvallidMoveException(string message) : base(message) { }

        public InvallidMoveException(string message, Exception innerException) : base(message, innerException) { }

        protected InvallidMoveException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
