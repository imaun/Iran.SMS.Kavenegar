using System.Linq;
using System.Collections.Generic;
using Iran.SMS.Kavenegar.Core.Models;

namespace Iran.SMS.Kavenegar.Core.Internal {

    /// <summary>
    /// Sms status translator.
    /// src: https://kavenegar.com/rest.html#result-send
    /// </summary>
    public static class SmsStatusTranslator {

        private static Dictionary<KavenegarMessageStatus, string> _statusTexts =
            new Dictionary<KavenegarMessageStatus, string> {
                { KavenegarMessageStatus.BlockedByReceptor, "	بلاک شده است، عدم تمایل گیرنده به دریافت پیامک از خطوط تبلیغاتی که هزینه آن به حساب برگشت داده می‌شود" },
                { KavenegarMessageStatus.CanceledByUserOrHasProblem, "ارسال پیام از سمت کاربر لغو شده یا در ارسال آن مشکلی پیش آمده که هزینه آن به حساب برگشت داده می‌شود" },
                { KavenegarMessageStatus.Delivered, "رسیده به گیرنده (Delivered)" },
                { KavenegarMessageStatus.Failed, "خطا در ارسال پیام که توسط سر شماره پیش می آید و به معنی عدم رسیدن پیامک می‌باشد" },
                { KavenegarMessageStatus.InQueueForSend, "در صف ارسال قرار دارد" },
                { KavenegarMessageStatus.InvalidId, "شناسه پیامک نامعتبر است ( به این معنی که شناسه پیام در پایگاه داده کاوه نگار ثبت نشده است یا متعلق به شما نمی‌باشد)" },
                { KavenegarMessageStatus.Scheduled, "زمان بندی شده (ارسال در تاریخ معین)" },
                { KavenegarMessageStatus.SentButUndelivered, "نرسیده به گیرنده ، این وضعیت به دلایلی از جمله خاموش یا خارج از دسترس بودن گیرنده اتفاق می افتد (Undelivered)" },
                { KavenegarMessageStatus.SentToOperator, "ارسال شده به مخابرات" },
                { KavenegarMessageStatus.SentToOperator2, "ارسال شده به مخابرات (همانند وضعیت 4)" }
            }

        public static string Translate(this KavenegarMessageStatus status)
            => _statusTexts.First(_ => _.Key == status).Value;
    }
}
