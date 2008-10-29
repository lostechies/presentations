namespace InternalDSL.Core.NotificationDSL.Model
{
    public class EmailNotification
    {
        public string To { get; set; }
        public string Cc { get; set; }
        public MessageTemplate Template { get; set; }
        public string Subject { get; set; }
    }
}