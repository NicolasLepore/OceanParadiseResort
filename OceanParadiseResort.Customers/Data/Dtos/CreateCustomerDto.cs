using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OceanParadiseResort.Customers.Data.Dtos
{
    public class CreateCustomerDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [Compare("Password")]
        public string? PasswordConfirmation { get; set;}

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
    }
}
