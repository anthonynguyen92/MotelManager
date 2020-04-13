using Newtonsoft.Json;

namespace Motel.Utilities.Exceptions
{
    public class MessageExceptions
    {
        public MessageExceptions()
        {
        }
        public string Message { get; set; }
        public MessageExceptions(string message)
        {
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(new { message = new string(Message) });
        }
    }
}
