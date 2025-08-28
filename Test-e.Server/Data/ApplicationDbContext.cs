using Microsoft.EntityFrameworkCore;
using Test_e.Server.Models;

namespace Test_e.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        // Product related
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<VariantAttributeValue> VariantAttributeValues { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductBadge> ProductBadges { get; set; }
        public DbSet<ProductBadgeAssignment> ProductBadgeAssignments { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }

        // User related
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Address> Addresses { get; set; }

        // Cart and Wishlist
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<RecentlyViewedProduct> RecentlyViewedProducts { get; set; }

        // Reviews
        public DbSet<Review> Reviews { get; set; }

        // Order related
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public DbSet<OrderAdjustment> OrderAdjustments { get; set; }
        public DbSet<OrderReturn> OrderReturns { get; set; }
        public DbSet<OrderReturnItem> OrderReturnItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }

        // Payment and Delivery
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DeliveryCompany> DeliveryCompanies { get; set; }
        public DbSet<DeliveryPrice> DeliveryPrices { get; set; }

        // Address lookup
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        // System
        public DbSet<Log> Logs { get; set; }
        public DbSet<AppSetting> AppSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure composite keys for junction tables
            modelBuilder.Entity<VariantAttributeValue>()
                .HasKey(vav => new { vav.ProductVariantId, vav.AttributeValueId });

            modelBuilder.Entity<ProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.TagId });

            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductVariant>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AttributeValue>()
                .HasOne(av => av.Attribute)
                .WithMany(a => a.AttributeValues)
                .HasForeignKey(av => av.AttributeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany(os => os.Orders)
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.ProductVariant)
                .WithMany(pv => pv.OrderItems)
                .HasForeignKey(oi => oi.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ProductVariant)
                .WithMany(pv => pv.CartItems)
                .HasForeignKey(ci => ci.ProductVariantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithMany(u => u.Wishlists)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(wi => wi.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Product)
                .WithMany(p => p.WishlistItems)
                .HasForeignKey(wi => wi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RecentlyViewedProduct>()
                .HasOne(rvp => rvp.User)
                .WithMany(u => u.RecentlyViewedProducts)
                .HasForeignKey(rvp => rvp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RecentlyViewedProduct>()
                .HasOne(rvp => rvp.Product)
                .WithMany(p => p.RecentlyViewedProducts)
                .HasForeignKey(rvp => rvp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.State)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<State>()
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .HasForeignKey(c => c.StateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderAdjustment>()
                .Property(a => a.AdjustmentType)
                .HasConversion<string>();

            modelBuilder.Entity<OrderAdjustment>()
                .HasOne(oa => oa.CreatedBy)
                .WithMany() // If you don’t need a back-reference collection in User
                .HasForeignKey(oa => oa.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderAdjustment>()
                  .HasOne(oa => oa.UpdatedBy)
                  .WithMany() // Same here
                  .HasForeignKey(oa => oa.UpdatedById)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(a => a.UserType)
                .HasConversion<string>();

            // Seed data for OrderStatuses
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Pending", Description = "Order is pending confirmation", IsActive = true },
                new OrderStatus { Id = 2, Name = "Confirmed", Description = "Order has been confirmed", IsActive = true },
                new OrderStatus { Id = 3, Name = "Processing", Description = "Order is being processed", IsActive = true },
                new OrderStatus { Id = 4, Name = "Shipped", Description = "Order has been shipped", IsActive = true },
                new OrderStatus { Id = 5, Name = "Delivered", Description = "Order has been delivered", IsActive = true },
                new OrderStatus { Id = 6, Name = "Cancelled", Description = "Order has been cancelled", IsActive = true },
                new OrderStatus { Id = 7, Name = "Returned", Description = "Order has been returned", IsActive = true }
            );

            // Seed data for PaymentStatus
            modelBuilder.Entity<PaymentStatus>().HasData(
                new PaymentStatus { Id = 1, Name = "Pending", Description = "Payment is pending", IsActive = true },
                new PaymentStatus { Id = 2, Name = "Failed", Description = "Payment has been Failed", IsActive = true },
                new PaymentStatus { Id = 3, Name = "Paid", Description = "Payment has been Paid", IsActive = true },
                new PaymentStatus { Id = 4, Name = "Cancelled", Description = "Payment has been cancelled", IsActive = true }
            );

            modelBuilder.Entity<UserPermission>()
                .HasKey(x => new { x.UserId, x.PermissionId });

            // Example seeding for Permissions
            modelBuilder.Entity<Permission>().HasData(
                new Permission { Id = 1, Key = "Dashboard.View", Description = "View dashboard" },
                new Permission { Id = 2, Key = "Products.View", Description = "View products" },
                new Permission { Id = 3, Key = "Products.Edit", Description = "Edit products" },
                new Permission { Id = 4, Key = "Orders.View", Description = "View orders" },
                new Permission { Id = 5, Key = "Orders.Edit", Description = "Edit orders" },
                new Permission { Id = 6, Key = "RegisterUsers", Description = "Register Users" },
                new Permission { Id = 7, Key = "OrderDiscount", Description = "Order Discount" },
                new Permission { Id = 8, Key = "Products", Description = "View Products" }
            );
         
        }
    }
   

}

