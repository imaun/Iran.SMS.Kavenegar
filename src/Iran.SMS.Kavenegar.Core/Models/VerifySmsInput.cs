using Newtonsoft.Json;

namespace Iran.SMS.Kavenegar.Core.Models {

    /// <summary>
    /// 
    /// </summary>
    public class VerifySmsInput {

        /// <summary>
        /// شماره گیرنده که می‌خواهید اعتبار سنجی شود
        /// در صورتی که شماره بین المللی است با کد کشور و دو صفر ارسال شود 00974211234565
        /// </summary>
        [JsonProperty("receptor")]
        public string Receptor { get; set; }

        /// <summary>
        /// می تواند حاوی کلیه کاراکترهای فارسی، انگلیسی و عدد باشد، به جز فضای خالی (Space)
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// می تواند حاوی کلیه کاراکترهای فارسی، انگلیسی و عدد باشد، به جز فضای خالی (Space)
        /// </summary>
        [JsonProperty("token2")]
        public string Token2 { get; set; }

        /// <summary>
        /// می تواند حاوی کلیه کاراکترهای فارسی، انگلیسی و عدد باشد، به جز فضای خالی (Space)
        /// </summary>
        [JsonProperty("token3")]
        public string Token3 { get; set; }

        /// <summary>
        /// می تواند حاوی کلیه کاراکترهای فارسی، انگلیسی و عدد باشد، به جز فضای خالی (Space)
        /// </summary>
        [JsonProperty("token10")]
        public string Token10 { get; set; }

        /// <summary>
        /// می تواند حاوی کلیه کاراکترهای فارسی، انگلیسی و عدد باشد، به جز فضای خالی (Space)
        /// </summary>
        [JsonProperty("token20")]
        public string Token20 { get; set; }

        /// <summary>
        /// 	نام الگوی تعریف شده برای اعتبار سنجی
        /// </summary>
        [JsonProperty("template")]
        public string Template { get; set; }

        /// <summary>
        /// نوع پیام را مشخص میکند (پیامک صوتی یا متنی) پیش فرض پیامک (sms) می‌باشد
        /// </summary>
        [JsonProperty("type")]
        public VerifyLookupType Type { get; set; }

    }
}
