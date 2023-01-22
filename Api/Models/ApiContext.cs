using Microsoft.EntityFrameworkCore;
using Api.Models;
using Api.Models.Sklad;

namespace Api.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sklad_rashod> Sklad_rashods { get; set; }
        public DbSet<Sklad_rashod_prods> Sklad_rashod_prods { get; set; }
        public DbSet<Shet> Shets { get; set; }
        public DbSet<Shet_prods> Shet_prods { get; set; }
        public DbSet<Type_oplaty> Types_oplaty { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sklad_prihod> Sklad_prihods { get; set; }
        public DbSet<Sklad_prihod_prods> Sklad_prihod_prods { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<Product_stock> Product_Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_stock>((pc =>
            {
                pc.HasNoKey();
                pc.ToView("product_stock_view");
            }));
        }
    }
}
