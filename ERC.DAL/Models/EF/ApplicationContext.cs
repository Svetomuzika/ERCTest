using ERCTest.DAL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERCTest.DAL.Models.EF
{
    public class ApplicationContext : DbContext
    {
        public DbSet<PersonalAccount> PersonalAccounts => Set<PersonalAccount>();
        public DbSet<Resident> Residents => Set<Resident>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\sozon\Desktop\ERCTest\ERCTest\ERC.DAL\bin\Debug\net5.0\ERCTest.db");
        }
    }
}
