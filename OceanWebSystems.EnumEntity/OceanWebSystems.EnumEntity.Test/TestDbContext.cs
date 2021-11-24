using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace OceanWebSystems.EnumEntity.Test
{
    internal class TestDbContext : DbContext
    {
        public virtual DbSet<TestEntityWithNonNullableEnum>? NonNullableTestEntities { get; set; }

        public virtual DbSet<TestEntityWithNullableEnum>? NullableTestEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(CreateInMemoryDatabase());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreateEnumEntityTables();
            base.OnModelCreating(modelBuilder);
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}
