using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
// using CustomerDetApi.Models;

namespace CustomerDetApi.Models
{
    public class CustDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source = Students.db;");
        }

        public DbSet<Customer> StudentsInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, custCode = "C0101", custName = "NAGPUR JAMESON TRADERS", custAddress = "69, Jameson street, Nagpur", custContactNo = "+919456789456", custEmail = "jameson@custdemoapi.com", country = 1 },
                new Customer() { Id = 1, custCode = "C0102", custName = "LALJI PAN MASALA", custAddress = "12/75, Bahadur Sastri Nagar, Indranagar, Bangalore", custContactNo = "+919475645456", custEmail = "laji.pan@gmail.com", country = 1 }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, countryCode = "IND", countryName = "INDIA" },
                new Country() { Id = 2, countryCode = "PAK", countryName = "PAKISTAN" },
                new Country() { Id = 3, countryCode = "SL", countryName = "SRI LANKA" },
                new Country() { Id = 4, countryCode = "BNG", countryName = "BANGLADESH" },
                new Country() { Id = 5, countryCode = "BHT", countryName = "BHUTAN" },
                new Country() { Id = 6, countryCode = "CHN", countryName = "CHINA" },
                new Country() { Id = 7, countryCode = "NPL", countryName = "NEPAL" },
                new Country() { Id = 8, countryCode = "AFG", countryName = "AFGHANISTHAN" },
                new Country() { Id = 9, countryCode = "MYN", countryName = "MYANMAR" },
                new Country() { Id = 10, countryCode = "THL", countryName = "THAILAND" },
                new Country() { Id = 11, countryCode = "CMB", countryName = "CAMBODIA" },
                new Country() { Id = 12, countryCode = "VTM", countryName = "VIETNAM" },
                new Country() { Id = 13, countryCode = "JPN", countryName = "JAPAN" },
                new Country() { Id = 14, countryCode = "SKOR", countryName = "SOUTH KOREA" },
                new Country() { Id = 15, countryCode = "USSR", countryName = "RUSSIAN FEDERATION" },
                new Country() { Id = 16, countryCode = "UK", countryName = "UNITED KINGDOM" },
                new Country() { Id = 17, countryCode = "DSH", countryName = "GERMANY" },
                new Country() { Id = 18, countryCode = "FR", countryName = "FRANCE" }
            );
        }
    }
}