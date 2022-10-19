using Domain;
using System.Data.Entity;

namespace DataBase
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Designer> Designers { get; set; }
        public DbSet<Architect> Architects { get; set; }
        public DbSet<Chart> Charts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelCharts(modelBuilder);

        }
        private void ModelCharts(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chart>()
           .HasMany<IDrawable>(c => c.Elements);

            modelBuilder.Entity<Chart>()
           .HasMany<Signature>(c => c.Signatures);
        }
    }
}
