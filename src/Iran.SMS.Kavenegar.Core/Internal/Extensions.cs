using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using Iran.SMS.Kavenegar.Core.Models;
using Iran.SMS.Kavenegar.Core.Internal;

namespace Iran.SMS.Kavenegar.Core.Extensions {

    public static class Extensions {

        /// <summary>
        /// The UNIX Epoch time
        /// </summary>
        private static readonly DateTime Epoch =
           new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Convert a <see cref="DateTime"/> value to correspondig Unix Timestamp.
        /// Note that you must send DateTime value in UTC for this method to work correctly.
        /// </summary>
        /// <param name="value">DateTime value to convert to Timestamp.</param>
        /// <returns>Unix Timestamp for the given <see cref="DateTime"/> value.</returns>
        public static long ToUnixTime(this DateTime value) {
            TimeSpan elapsedTime = value - Epoch;
            long totalSeconds = Convert.ToInt64(elapsedTime.TotalSeconds);
            //return long.Parse(elapsedTime.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            return totalSeconds;
        }

        public static DateTime ToDateTime(this long unixTimeValue)
            => Epoch.AddSeconds(unixTimeValue).ToLocalTime();

        public static string GetMobileNumbersAsString(
            this IEnumerable<MobileNumber> source,
            char delimeter = ',') {
            var result = source.Aggregate("",
                (current, mobile)
                    => current + (mobile.ToString() + delimeter));
            return result.Substring(0, result.Length - 1);
        }

        public static string GetLocalIdsAsString<T>(
            this IEnumerable<T> localIds,
            char delimeter = ',') {
            var result = string.Empty;
            if (localIds == null || !localIds.Any())
                return result;
            
            foreach (T item in localIds)
                result += $"{item}{delimeter}";

            return result.Substring(0, result.Length - 1);
        }

        public static string ToUrlEncode(this string what)
            => HttpUtility.UrlEncode(what);

        public static KeyValuePair<string, string> GetKeyValue(string key, string value)
            => new KeyValuePair<string, string>(key, value);

        public static KavenegarSendSmsInput ToKavenegarModel<T>(
            this SendSmsInput<T> model)
                => new KavenegarSendSmsInput {
                    DisplayType = (int)model.DisplayType,
                    Hide = Convert.ToByte(model.HideInWebConsole),
                    Message = model.Message.ToUrlEncode(),
                    Receptor = model.ReceptorMobileNumbers
                        .GetMobileNumbersAsString().ToUrlEncode(),
                    SendDate = model.SendDate == DateTime.MinValue 
                        ? 0 
                        : model.SendDate.ToUnixTime(),
                    SenderLineNumber = model.SenderLineNumber.ToUrlEncode(),
                    LocalIds = model.LocalIds.GetLocalIdsAsString()
                };

        public static IEnumerable<KeyValuePair<string, string>> ToFormData<T>(
            this SendSmsInput<T> model) 
                => new List<KeyValuePair<string, string>> {
                    { GetKeyValue("sender", model.SenderLineNumber) },
                    { GetKeyValue(
                        "receptor", 
                        model.ReceptorMobileNumbers.GetMobileNumbersAsString()
                    ) },
                    { GetKeyValue("message", model.Message) },
                    { GetKeyValue("type", ((int)model.DisplayType).ToString()) },
                    { 
                        GetKeyValue("date", model.SendDate == DateTime.MinValue 
                            ? "0"
                            : model.SendDate.ToUnixTime().ToString()) 
                    },
                    { GetKeyValue("localid", model.LocalIds.GetLocalIdsAsString()) },
                    { GetKeyValue("hide", Convert.ToByte(model.HideInWebConsole).ToString()) }
                };

        public static IEnumerable<KeyValuePair<string, string>> ToFormData(this VerifySmsInput model)
            => new List<KeyValuePair<string, string>> {
                { GetKeyValue("receptor", model.Receptor) },
                { GetKeyValue("token", model.Token) },
                { GetKeyValue("token2", model.Token2) },
                { GetKeyValue("token3", model.Token3) },
                { GetKeyValue("template", model.Template) },
                { GetKeyValue("type", model.Type.ToString()) }
            };

    }
}
