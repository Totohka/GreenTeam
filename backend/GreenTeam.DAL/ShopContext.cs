using GreenTeam.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace GreenTeam.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cheque> Cheques { get; set; }
        public DbSet<ChequeProduct> ChequeProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>().HaveConversion<DateTime>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(CategoryConfigure);
            modelBuilder.Entity<Product>(ProductConfigure);
            modelBuilder.Entity<Role>(RoleConfigure);
            modelBuilder.Entity<User>(UserConfigure);
            modelBuilder.Entity<Cheque>(ChequeConfigure);
            modelBuilder.Entity<ChequeProduct>(ChequeProductConfigure);
            modelBuilder.Entity<Supplier>(SupplierConfigure);
        }
        public void CategoryConfigure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        }
        public void ProductConfigure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.SupplierId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
        public void RoleConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        }
        public void UserRoleConfigure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RoleId).IsRequired();
        }
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(25);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(182);
            builder.Property(p => p.Password).IsRequired();
        }
        public void ChequeConfigure(EntityTypeBuilder<Cheque> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Path).IsRequired().HasMaxLength(50);
            builder.Property(p => p.UserId).IsRequired();
        }
        public void ChequeProductConfigure(EntityTypeBuilder<ChequeProduct> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductAmount).IsRequired();
            builder.Property(p => p.ProductId).IsRequired();
            builder.Property(p => p.ChequeId).IsRequired();
        }
        public void SupplierConfigure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(200);
        }
    }
}
