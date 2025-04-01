using AutoMapper.Execution;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanParadiseResort.Customers.Models;
using OceanParadiseResort.Customers.ValueObjects;

namespace OceanParadiseResort.Customers.Data
{
    public class AppUserContext : IdentityDbContext<Customer>
    {
        public AppUserContext(DbContextOptions opt) : base(opt)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
