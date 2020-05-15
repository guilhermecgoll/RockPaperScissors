﻿using System;
using System.Runtime.Serialization;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class WrongNumberOfPlayersException : Exception
    {
        public WrongNumberOfPlayersException() { }

        public WrongNumberOfPlayersException(string message) : base(message) { }

        public WrongNumberOfPlayersException(string message, Exception innerException) : base(message, innerException) { }

        protected WrongNumberOfPlayersException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
