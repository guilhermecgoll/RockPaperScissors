using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Exceptions
{
    [Serializable()]
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() { }

        public NoSuchStrategyError(string message) : base(message) { }

        public NoSuchStrategyError(string message, Exception innerException) : base(message, innerException) { }

        protected NoSuchStrategyError(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
