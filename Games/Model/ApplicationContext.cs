using System;
using Games.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Games.Model
{
    public class ApplicationContext : DbContext
    {

        private string _databasePath;

        public DbSet<User> Users { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

    }
}
