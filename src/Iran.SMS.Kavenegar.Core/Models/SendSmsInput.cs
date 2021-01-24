using System;
using System.Collections.Generic;

namespace Iran.SMS.Kavenegar.Core.Models
{
    /// <summary>
    /// Sms input model. T is the type of your entity Id property.
    /// </summary>
    /// <typeparam name="T">T is the type of your entity Id property.</typeparam>
    public class SendSmsInput<T>
    {
        public SendSmsInput() {
            ReceptorMobileNumbers = new List<MobileNumber>();
            LocalIds = new List<T>();
        }

        public ICollection<MobileNumber> ReceptorMobileNumbers { get; set; }
        public string Message { get; set; }
        public string SenderLineNumber { get; set; }
        public DateTime SendDate { get; set; }
        public MessageDisplayType DisplayType { get; set; }
        public ICollection<T> LocalIds { get; set; }
        public bool HideInWebConsole { get; set; }
    }
}
