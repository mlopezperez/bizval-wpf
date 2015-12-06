using System;
using System.Runtime.Serialization;

namespace BizVal
{
    [Serializable]
    public class AggregationException : Exception
    {
        public AggregationException()
        {
        }

        public AggregationException(string message)
            : base(message)
        {
        }

        public AggregationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected AggregationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
