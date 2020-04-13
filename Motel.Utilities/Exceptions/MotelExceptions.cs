using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Motel.Utilities.Exceptions
{
    [Serializable]
    public class MotelExceptions : Exception
    {
        public int StatusCode { get; set; }
        public string messageDetail { get; set; }
        public MotelExceptions(HttpStatusCode statusCode, string message =null,string messagedetail = null) : base(message)
        {
            StatusCode = (int)statusCode;
            messageDetail = messagedetail;
        }

        public MotelExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MotelExceptions(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }
}
