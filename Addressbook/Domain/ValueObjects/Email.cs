using System;
using System.Text.RegularExpressions;

namespace Addressbook.Domain.ValueTypes
{
    public class Email
    {
        public Email() { }
        public Email(string email)
        {
            if (IsEmail(email))
                Value = email;
            else
            {
                throw new ArgumentException("Must be a email address");
            }
        }

        public static bool TryParse(string email, out Email result)
        {
            try
            {
                result = new Email(email);
                return true;
            }
            catch (ArgumentException)
            {
                result = null;
                return false;
            }
        }
        public static bool IsEmail(string email)
        {
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
        public string Value { get; set; }
    }
}
