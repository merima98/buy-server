using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Buy.Models.Entities
{
    public partial class buyPlatformContext : DbContext
    {
        public buyPlatformContext()
        {
        }

        public buyPlatformContext(DbContextOptions<buyPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<HistoryPurchase> HistoryPurchases { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOnCart> ProductOnCarts { get; set; }
        public virtual DbSet<ScriptExecutionHistoy> ScriptExecutionHistoys { get; set; }
        public virtual DbSet<SoldProduct> SoldProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=buyPlatform;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("Condition");

                entity.Property(e => e.ConditionId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<HistoryPurchase>(entity =>
            {
                entity.ToTable("HistoryPurchase");

                entity.Property(e => e.HistoryPurchaseId).ValueGeneratedNever();

                entity.Property(e => e.TotalPriceOfPurchase).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShippingPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Category_Product_CategoryId");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Condition_Product_ConditionId");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_Product_CreatorId");
            });

            modelBuilder.Entity<ProductOnCart>(entity =>
            {
                entity.HasKey(e => e.ProductOnCart1)
                    .HasName("Pk_ProductOnCart_ProductOnCart");

                entity.ToTable("ProductOnCart");

                entity.Property(e => e.ProductOnCart1)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductOnCart");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.ProductOnCarts)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Cart_ProductOnCart_CartId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOnCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Product_ProductOnCart_ProductId");
            });

            modelBuilder.Entity<ScriptExecutionHistoy>(entity =>
            {
                entity.HasKey(e => e.ScriptId)
                    .HasName("Pk_ScriptExecutionHistoy_ScriptId");

                entity.ToTable("ScriptExecutionHistoy");

                entity.Property(e => e.ScriptId).ValueGeneratedNever();
            });

            modelBuilder.Entity<SoldProduct>(entity =>
            {
                entity.ToTable("SoldProduct");

                entity.Property(e => e.SoldProductId).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PriceOfProduct).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TotalPriceOfProduct).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.HistoryPurchase)
                    .WithMany(p => p.SoldProducts)
                    .HasForeignKey(d => d.HistoryPurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_HistoryPurchase_SoldProduct_HistoryPurchaseId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SoldProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Product_SoldProduct_ProductId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SoldProducts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_User_SoldProduct_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnName("ImageURL");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Cart_User_CartId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_City_User_CityId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
