using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;

namespace OnlineStore.Storage.MS_SQL
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Manager> Managers { get; set; }
        //public DbSet<ProductToSales> ProductToSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Manager>()
                .HasIndex(manager => manager.Email).IsUnique(true);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Sales)
                .WithOne(Sale => Sale.Client)
                .HasForeignKey(Sale => Sale.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                .HasMany(p => p.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Sales)
                .UsingEntity(j => j.ToTable("ProductsToSales"));
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = localhost, 1433;DataBase = OnlineStoreDataBase;User ID = sa;Password=sjfkdjFDF!so12fjks;MultipleActiveResultSets=true;TrustServerCertificate=True");
        //}

    }
}
