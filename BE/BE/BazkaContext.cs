using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Services;
using Microsoft.EntityFrameworkCore;

namespace BE
{
    public class BazkaContext : DbContext
    {
        ConnectionStringProvider provider;

        public BazkaContext(ConnectionStringProvider _provider)
        {
            provider = _provider;
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGames> UserGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(provider.GetConnectionString());
        }
    }
}
