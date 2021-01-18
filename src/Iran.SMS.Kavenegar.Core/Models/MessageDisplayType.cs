﻿namespace Iran.SMS.Kavenegar.Core.Models
{
    public enum MessageDisplayType
    {
        /// <summary>
        /// پیامک بصورت مستقیم برروی صفحه موبایل شخص گیرنده ظاهرمی‌شود
        /// .این حالت پیامک درموبایل یا سیم کارت شخص گیرنده
        /// بصورت اتوماتیک ذخیره نمی‌شود و با خروج از آن حذف می‌شود(پیامک خبری)
        /// </summary>
        News = 0,

        /// <summary>
        /// در حافظه ﻣﻮﺑﺎﻳﻞ ﺷﺨﺺ گیرنده ذخیره می‌شود.
        /// (پیامک عادی) در صورتی که پارامتر مربوطه خالی 
        /// ارسال شود به صورت پیش فرض پیامک مورد نظر با این نوع ارسال می‌شود
        /// </summary>
        Normal = 1,

        /// <summary>
        /// پیامک برروی حافظه سیمکارت گوشی گیرنده ذخیره می‌شود
        /// </summary>
        NormalSaveToSIM = 2,

        /// <summary>
        /// درصورتی که موبایل شخص گیرنده دارای یک نرم افزار کابردی خاص برای ذخیره پیامک باشد و
        /// یا به یک نرم افزار کاربردی خاص برروی یک کامپیوترمتصل باشد،
        /// پیامک دریافتی درآن نرم افزارها ذخیره می‌شود
        /// </summary>
        NormalSaveToSMSProgram = 3
    }
}
