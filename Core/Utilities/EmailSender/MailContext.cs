using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.EmailSender
{
    public class MailContext
    { 
        public string HostEmail { get; set; }
        public string HostEmailPassword { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string DisplayName { get; set; }
    }
}
