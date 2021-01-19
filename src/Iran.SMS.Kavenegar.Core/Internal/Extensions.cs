using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using Iran.SMS.Kavenegar.Core.Models;
using Iran.SMS.Kavenegar.Core.Internal;

namespace Iran.SMS.Kavenegar.Core.Extensions {

    public static class Extensions {

        private static readonly DateTime Epoch =
           new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to correspondig Unix Timestamp.
        /// Note that you must send DateTime value in UTC for this method to work correctly.
        /// </summary>
        /// <param name="value">DateTime value to convert to Timestamp.</param>
        /// <returns>Unix Timestamp for the given <see cref="DateTime"/> value.</returns>
        public static long ToTimestamp(this DateTime value) {
            TimeSpan elapsedTime = value - Epoch;
            return long.Parse(elapsedTime.TotalSeconds.ToString(CultureInfo.InvariantCulture));
        }

        public static string GetMobileNumbersAsString(
            this IEnumerable<MobileNumber> source,
            string delimeter = ",") {
            var result = source.Aggregate("", 
                (current, mobile) 
                    => current + (mobile.ToString() + delimeter));
            return result.Substring(0, result.Length - 1);
        }

        public static KavenegarSendSmsInput ToKavenegarModel<T>(
            this SendSmsInput<T> model) {
            var result = new KavenegarSendSmsInput {
                DisplayType = model.DisplayType.ToString(),
                Hide = byte.Parse(model.HideInWebConsole.ToString()),
                Message = model.Message,
                Receptor = model.ReceptorMobileNumbers.GetMobileNumbersAsString(),
                SendDate = model.SendDate.ToTimestamp(),
                SenderLineNumber = model.SenderLineNumber
            };

            return result;
        }
    }
}
