using System.ComponentModel.DataAnnotations;

namespace OceanParadiseResort.Customers.Data.Dtos
{
    public class LoginCustomerDto
    {
        [Required]
        public string? Username { get; set; }

        //[Required]
        //[EmailAddress]
        //public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
