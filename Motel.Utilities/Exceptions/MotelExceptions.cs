using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Motel.Utilities.Exceptions
{
    [Serializable]
    public class MotelExceptions : Exception
    {

        public MotelExceptions(string message) : base(message)
        {
        }

        public MotelExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MotelExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
