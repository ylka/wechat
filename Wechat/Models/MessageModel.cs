namespace Wechat.Models
{
    public class MessageModel
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public int CreateTime { get; set; }

        public string MsgType { get; set; }

        public string Content { get; set; }

        public int MsgId { get; set; }
    }
}
