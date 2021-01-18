using System;
using System.Collections.Generic;
using System.Text;

namespace Iran.SMS.Kavenegar.Core.Models
{
    public class SendSmsInput
    {
        public ICollection<MobileNumber> ReceptorMobileNumbers { get; set; }
        public string Message { get; set; }
        public string SenderLineNumber { get; set; }
        public DateTime SendDate { get; set; }
        public MessageDisplayType DisplayType { get; set; }
        public ICollection<string> LocalIds { get; set; }
        public bool HideInWebConsole { get; set; }
    }
}
