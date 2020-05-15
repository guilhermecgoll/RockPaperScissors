using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class ZeroPlayersSubscribedException : Exception
    {
        public ZeroPlayersSubscribedException() : base("No players were sign up for this tournament")
        {
        }

        public ZeroPlayersSubscribedException(string message) : base(message)
        {
        }

        public ZeroPlayersSubscribedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroPlayersSubscribedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}