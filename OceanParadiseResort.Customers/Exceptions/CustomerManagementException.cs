using Microsoft.AspNetCore.Identity;

namespace OceanParadiseResort.Customers.Exceptions
{
    public class CustomerManagementException : Exception
    {
        public CustomerManagementException(string message) : base(message)
        { }

        public CustomerManagementException(string message, IEnumerable<IdentityError> errors) : base(message: $"{message} {ErrorListToString(errors)}")
        { }

        private static string ErrorListToString(IEnumerable<IdentityError> errors)
        {
            string errorText = "\n================================\nLista de erros: ";
            foreach (var error in errors) 
            {
                errorText += $"\n{error.Description}";
            }

            errorText += "\n================================";
            return errorText;
        }
    }
}
