using Microsoft.EntityFrameworkCore;
using Store.Domain;
using Store.Domain.Common;
using System.Reflection;

namespace Store.Persistence
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                 .HasOne(p => p.CreatedBy)
                 .WithMany()
                 .HasForeignKey(p => p.CreatedById)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
                  .HasOne(p => p.Brand)
                  .WithMany()
                  .HasForeignKey(p => p.BrandId)
                  .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDetail>()
                 .HasOne(od => od.Product)
                 .WithMany()
                 .HasForeignKey(od => od.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddDefaultValueForBaseDomainEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override int SaveChanges()
        {
            AddDefaultValueForBaseDomainEntities();
            return base.SaveChanges();
        }
        private void AddDefaultValueForBaseDomainEntities()
        {
            foreach (var item in ChangeTracker.Entries<BaseDomainEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.CreatedById = 1;
                    item.Entity.CreateTime = DateTime.Now;
                }
            }
        }
    }
}
