using System;
using Games.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Games.Model
{
    public class ApplicationContext : DbContext
    {

        private readonly string _databasePath;

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        #region -- Public properties --

        public DbSet<User> Users { get; set; }

        #endregion

        #region -- Overrides --

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        #endregion

    }
}
