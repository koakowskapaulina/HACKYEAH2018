using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using Microsoft.EntityFrameworkCore;

namespace BE
{
    public class BazkaContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:hackyeah18.database.windows.net,1433;Initial Catalog=hackyeah;Persist Security Info=False;User ID=hackyeah18;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
