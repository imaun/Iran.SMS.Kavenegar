using System;
using System.Globalization;

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

    }
}
