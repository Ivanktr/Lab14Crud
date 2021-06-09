using System;
using System.Collections.Generic;
using System.Text;

namespace Lab14Crud.Database
{
    public class ComponentContext : DbContext
    {
        public DbSet<ComponentModel> TbComponents { get; set; }
        public ComponentContext()
        {
            //Solo necesario para iniciar SQLite en iOS
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "ComponentsDB.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
