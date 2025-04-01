using Microsoft.AspNetCore.Identity;
using OceanParadiseResort.Customers.ValueObjects;

namespace OceanParadiseResort.Customers.Models
{
    public class Customer : IdentityUser
    {
        public Customer() : base()
        { }

        private string _id = Guid.NewGuid().ToString();
        private string _email;

        public override string Id => this._id;
        public override string? Email
        {
            get => this._email;
            set => this._email = new Email($"{value}").Value;
        }
        public DateOnly Birthday { get; set; }
    }
}
