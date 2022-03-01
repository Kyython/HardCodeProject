using HCP.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace HCP.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CustomAttribute> CustomAttributes { get; set; }

        public DbSet<CustomAttributeOption> CustomAttributeOptions { get; set; }

        public DbSet<Product_CustomAttribute_Mapping> Product_CustomAttribute_Mappings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
