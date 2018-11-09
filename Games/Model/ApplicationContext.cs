using System;
using Games.Model.Data;
using Microsoft.EntityFrameworkCore;

namespace Games.Model
{
    public class ApplicationContext : DbContext
    {

        #region -- Private helpers --

        private readonly string _databasePath;

        #endregion

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        #region -- Public properties --

        public DbSet<User> Users { get; set; }

        #endregion

        #region -- Private helpers --

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        #endregion
    }
}
