using Microsoft.EntityFrameworkCore;
using OceanParadiseResort.Bedrooms.Models;

namespace OceanParadiseResort.Bedrooms.Data
{
    public class AppBedroomContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbSet<Bedroom> Bedrooms { get; set; }

        public AppBedroomContext(IConfiguration config)
        {
            _configuration = config;
            _connectionString = _configuration.GetConnectionString("DbConnectionString")!;
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
            
        }
    }
}
