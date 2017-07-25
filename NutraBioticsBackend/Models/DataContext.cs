namespace NutraBioticsBackend.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<NutraBioticsBackend.Models.ShipTo> ShipToes { get; set; }

        public System.Data.Entity.DbSet<NutraBioticsBackend.Models.Contact> Contacts { get; set; }
    }
}