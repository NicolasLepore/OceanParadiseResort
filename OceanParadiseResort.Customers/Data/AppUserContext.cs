using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OceanParadiseResort.Customers.Models;

namespace OceanParadiseResort.Customers.Data
{
    public class AppUserContext : IdentityDbContext<Customer>
    {
        public AppUserContext(DbContextOptions opt) : base(opt)
        { }


    }
}
