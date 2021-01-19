using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Iran.SMS.Kavenegar.Core.Models {

    public class SendSmsOutput: ApiResult<IEnumerable<SendSmsOutputItem>>{ }

    public class SendSmsOutputItem {
        /// <summary>
        /// شناسه یکتای این پیامک (برای اطلاع از وضعیت پیامک ارسالی این مقدار ورودی متد Status می‌باشد.)
        /// </summary>
        [JsonProperty("messageid")]
        public long Id { get; set; }

        /// <summary>
        /// متن پیام ارسال شده
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// وضعیت عددی این پیامک (اطلاعات بیشتر جدول وضعیت پیامک ها)
        /// </summary>
        [JsonProperty("status")]
        public KavenegarMessageStatus Status { get; set; }

        /// <summary>
        /// متن توضیح وضعیت عددی این پیامک (اطلاعات بیشتر جدول وضعیت پیامک ها)
        /// </summary>
        [JsonProperty("statustext")]
        public string StatusText { get; set; }

        /// <summary>
        /// شماره فرستنده
        /// </summary>
        [JsonProperty("sender")]
        public string SenderLineNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public MobileNumber ReceptorMobileNumber { get; set; }

        /// <summary>
        /// شماره گیرنده
        /// </summary>
        [JsonProperty("receptor")]
        private string Receptor { get; set; }

        
        public DateTime SentDateValue { get; }

        /// <summary>
        /// زمان ارسال این پیامک به فرمت UnixTime
        /// </summary>
        [JsonProperty("date")]
        public long SentDate { get; set; }

        /// <summary>
        /// هزینه این پیامک ( ریال)
        /// </summary>
        [JsonProperty("cost")]
        public int Cost { get; set; }
    }
}
