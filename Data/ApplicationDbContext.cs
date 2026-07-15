using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<OrderCoupon> OrderCoupons { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ---------- Unique constraints ----------
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.RoleName).IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderNumber).IsUnique();

            modelBuilder.Entity<Coupon>()
                .HasIndex(c => c.Code).IsUnique();

            modelBuilder.Entity<ShoppingCart>()
                .HasIndex(c => c.UserId).IsUnique();

            modelBuilder.Entity<Wishlist>()
                .HasIndex(w => w.UserId).IsUnique();

            // ---------- Direct parent -> child (owned) relationships: Cascade ----------
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(c => c.User)
                .WithOne(u => u.ShoppingCart)
                .HasForeignKey<ShoppingCart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Wishlist>()
                .HasOne(w => w.User)
                .WithOne(u => u.Wishlist)
                .HasForeignKey<Wishlist>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Wishlist)
                .WithMany(w => w.WishlistItems)
                .HasForeignKey(wi => wi.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Book)
                .WithMany(b => b.BookAuthors)
                .HasForeignKey(ba => ba.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderCoupon>()
                .HasOne(oc => oc.Order)
                .WithMany(o => o.OrderCoupons)
                .HasForeignKey(oc => oc.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // ---------- Cross-references that would create multiple cascade paths: Restrict ----------
            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Book)
                .WithMany(b => b.CartItems)
                .HasForeignKey(ci => ci.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WishlistItem>()
                .HasOne(wi => wi.Book)
                .WithMany(b => b.WishlistItems)
                .HasForeignKey(wi => wi.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ShippingMethod)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShippingMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.PaymentMethod)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Book)
                .WithMany(b => b.OrderDetails)
                .HasForeignKey(od => od.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.Order)
                .WithMany(o => o.Deliveries)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Delivery>()
                .HasOne(d => d.ShippingMethod)
                .WithMany(s => s.Deliveries)
                .HasForeignKey(d => d.ShippingMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderCoupon>()
                .HasOne(oc => oc.Coupon)
                .WithMany(c => c.OrderCoupons)
                .HasForeignKey(oc => oc.CouponId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryTransaction>()
                .HasOne(it => it.Book)
                .WithMany(b => b.InventoryTransactions)
                .HasForeignKey(it => it.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}