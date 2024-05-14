using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp5
{
    public static class Validator
    {
        static readonly Regex IntRegex = new Regex("[0-9]");

        static readonly Regex NameRegex = new Regex("^([А-ЯЁа-яё]+)\\s+([А-ЯЁа-яё]+)\\s+([А-ЯЁа-яё]+)$");

        static readonly Regex EmailRegex = new Regex("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$");
        public static bool ValidateName(string text)
        {
            return NameRegex.IsMatch(text);
        }
        public static bool ValidateNumber(string text)
        {
            return IntRegex.IsMatch(text);
        }

        public static bool ValidateEmail(string text)
        {
            return EmailRegex.IsMatch(text);
        }
    }
}
