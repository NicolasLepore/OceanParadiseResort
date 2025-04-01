using System.Text.RegularExpressions;

namespace OceanParadiseResort.Customers.ValueObjects
{
    public class Email
    {
        public Email(string value)
        {
            string pattern =
                "^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$";

            if (!Regex.IsMatch(value, pattern))
                throw new ArgumentException("Email invalido!");
                
            Value = value;
        }

        public string Value { get; private set; }
    }
}
