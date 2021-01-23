using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Iran.SMS.Kavenegar.Core.Internal {

    public class KavenegarSendSmsInput {
        /// <summary>
        /// شماره دریافت کننده پیامک را مشخص می کند که می توان با کاراکتر ویرگول « , » آنها را از هم جدا کرد
        /// </summary>
        [JsonProperty("receptor")]
        public string Receptor { get; set; }

        /// <summary>
        ///متن پیام کوتاه ، متن مورد نظر را در حالت POST یا GET حتما باید Encode کنید
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// شماره خط ارسال کننده پیام
        /// </summary>
        [JsonProperty("sender")]
        public string SenderLineNumber { get; set; }

        /// <summary>
        /// زمان ارسال پیام ( در صورتی که خالی باشد پیام به صورت خودکار در همان لحظه ارسال می‌شود )
        /// </summary>
        [JsonProperty("date")]
        public long SendDate { get; set; }

        /// <summary>
        /// نوع پیام در گوشی گیرنده می‌باشد (جدول شماره 3) فقط برای خطوط 3000 امکان پذیر است
        /// </summary>
        [JsonProperty("type")]
        public int DisplayType { get; set; }

        /// <summary>
        /// شناسه محلی در پایگاه داده های شما است ، اطلاعات بیشتر در بخش یادداشت نوشته شده
        /// </summary>
        [JsonProperty("localid")]
        public string LocalIds { get; set; }

        /// <summary>
        /// اگر مقداری عددی پارامتر hide برابر 1 باشد شماره گیرنده در فهرست ارسال ها و کنسول وب نمایش داده نمی شود.
        /// </summary>
        [JsonProperty("hide")]
        public byte Hide { get; set; }
    }
}
