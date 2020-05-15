using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class TournamentClosedException : Exception
    {
        public TournamentClosedException() : base("The subscription for this tournament are over.")
        {
        }

        public TournamentClosedException(string message) : base(message)
        {
        }

        public TournamentClosedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TournamentClosedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}