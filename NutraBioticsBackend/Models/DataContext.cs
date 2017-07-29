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

        public DbSet<ShipTo> ShipToes { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<PriceList> PriceLists { get; set; }

        public DbSet<PriceListPart> PriceListParts { get; set; }

        public DbSet<CustomerPriceList> CustomerPriceLists { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}