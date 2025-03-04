using Microsoft.AspNetCore.Identity;

namespace OceanParadiseResort.Customers.Models
{
    public class Customer : IdentityUser
    {
        public Customer() : base()
        { }

        private string _id = Guid.NewGuid().ToString();
        public override string Id => this._id;
        public DateOnly Birthday { get; set; }
    }
}
