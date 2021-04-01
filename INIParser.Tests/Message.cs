using INIParser.Attributes;

namespace INIParser.Tests
{
    public class Message
    {

        [IniPropertyName("message_id")]
        public int MessageId { get; set; }
        [IniPropertyName("sender_phone")]
        public string SenderPhone { get; set; }
        [IniPropertyName("sender_name")]
        public string SenderName { get; set; }
        [IniPropertyName("recepient_name")]
        public string RecepientName { get; set; }
        [IniPropertyName("recepient_phone")]
        public string RecepientPhone { get; set; }
        [IniPropertyName("content")]
        public string Content { get; set; }


        public Message()
        {

        }
    }
}
