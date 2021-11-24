using Microsoft.EntityFrameworkCore;

namespace OceanWebSystems.EnumEntity.Sample
{
    public class TrainingDbContext : DbContext
    {
        private readonly string ConnectionString = "Data Source=.;Initial Catalog=EnumEntitySample;Integrated Security=True;";

        public virtual DbSet<Programme>? Programmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.CreateEnumEntityTables();
            base.OnModelCreating(modelBuilder);
        }
    }
}
