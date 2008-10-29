using System.Collections.Generic;

namespace InternalDSL.Core.NotificationDSL.Model
{
    public class MessageTemplate
    {
        public string Name { get; set; }
        public IDictionary<string, object> Parameters { get; set; }
        public string Body { get; set; }
    }
}