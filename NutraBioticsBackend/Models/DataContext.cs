namespace NutraBioticsBackend.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}