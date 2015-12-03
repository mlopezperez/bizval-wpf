using System;
using System.Runtime.Serialization;

namespace BizVal
{
    public class ValuationException: Exception
    {
        public ValuationException()
        {
        }

        public ValuationException(string message) : base(message)
        {
        }

        public ValuationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValuationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
