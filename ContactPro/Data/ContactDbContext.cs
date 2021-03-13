using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactPro.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ContactPro.Data
{
    public class ContactDbContext : DbContext
    {
        
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

                var connectionString = configuration.GetConnectionString("ContactDbContext");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .ToTable("Contact","dbo");
        }
        public DbSet<ContactPro.Entities.Contact> Contact { get; set; }
    }
}
