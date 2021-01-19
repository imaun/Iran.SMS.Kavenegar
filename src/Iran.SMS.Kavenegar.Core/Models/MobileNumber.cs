using System;
using System.Text.RegularExpressions;

namespace Iran.SMS.Kavenegar.Core.Models
{
    public class MobileNumber
    {
        private static readonly Regex _matchMobileNumber1 = new Regex(@"^(((98)|(\+98)|(0098)|0)(9){1}[0-9]{9})+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: TimeSpan.FromMinutes(1));
        private static readonly Regex _matchMobileNumber2 = new Regex(@"^(9){1}[0-9]{9}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase, matchTimeout: TimeSpan.FromMinutes(1));

        public MobileNumber() {  }

        public MobileNumber(string value)
            => Value = value;

        private string _value;
        public string Value {
            get => _value;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("MobileNumber");

                if (!_matchMobileNumber1.IsMatch(value) &&
                    !_matchMobileNumber2.IsMatch(value))
                    throw new ArgumentException("MobileNumber format is not valid.");

                _value = value;
            }
        }

        public override string ToString() 
            => _value;

    }
}
