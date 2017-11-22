using System.Text.RegularExpressions;

namespace DataValidation
{
    public class InputValidator
    {
        public bool ValidName(string name)
        {
            string namePattern = @"^([A-ZÀ-Ű][A-Za-zÀ-ÿ]+\s?)+$";
            return Regex.IsMatch(name, namePattern);
        }

        public bool ValidPhone(string phoneNumber)
        {
            string hungarianPhonePattern = @"^\+36[-/]((1|[237]0)[-/]\d{3}[-/]?\d{4})|([1-9]{2}[-/]\d{3}[-/]?\d{3})$";
            return Regex.IsMatch(phoneNumber, hungarianPhonePattern);
        }

        public bool ValidEmail(string email)
        {
            string emailPattern = @"^[A-Za-z0-9_\.]+\@\w+\.\w{2,3}$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
