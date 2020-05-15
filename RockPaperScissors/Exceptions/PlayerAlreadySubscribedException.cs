using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class PlayerAlreadySubscribedException : Exception
    {
        public PlayerAlreadySubscribedException() : base("The given player is already subscribed on the tournamet") { }

        public PlayerAlreadySubscribedException(string message) : base($"The player {message} is already subscribed on the tournamet") { }

        public PlayerAlreadySubscribedException(string message, Exception innerException) : base(message, innerException) { }

        protected PlayerAlreadySubscribedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
