using CafeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Data
{
    public class CafeDbContext : DbContext
    {
        public CafeDbContext(DbContextOptions<CafeDbContext> options)
            : base(options)
        {
        }
        // khai báo bảng trong database
        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<CafeTable> CafeTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        // hardcode seed data for categories and products
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
        .HasIndex(x => x.Username)
        .IsUnique();
            // seed data for roles
            modelBuilder.Entity<Role>().HasData(

    new Role
    {
        Id = 1,
        RoleName = "Admin"
    },

    new Role
    {
        Id = 2,
        RoleName = "Staff"
    },

    new Role
    {
        Id = 3,
        RoleName = "Customer"
    }
);
            // seed data for users
            modelBuilder.Entity<User>().HasData(

      new User
      {
          Id = 1,
          FullName = "Administrator",
          Username = "admin01",
          Password = "123456",
          Email = "Admin@cafe.com",
          IsActive = true,
          RoleId = 1
      },

      new User
      {
          Id = 2,
          FullName = "MayCafe",
          Username = "staff01",
          Password = "123456",
          Email = "May@cafe.com",
          IsActive = true,
          RoleId = 2
      },

      new User
      {
          Id = 3,
          FullName = "Tran Hoang Anh",
          Username = "customer01",
          Password = "123456",
          Email = "THA@gmail.com",
          IsActive = true,
          RoleId = 3
      }
  );

            // ======================
            // CATEGORY SEED DATA
            // ======================
            modelBuilder.Entity<Category>().HasData(

                new Category
                {
                    Id = 1,
                    CategoryName = "Cà phê"
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "Trà & Trà sữa"
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "Nước ép & Sinh tố"
                },

                new Category
                {
                    Id = 4,
                    CategoryName = "Bánh ngọt"
                },

                new Category
                {
                    Id = 5,
                    CategoryName = "Đồ ăn vặt"
                }
            );

            // ======================
            // PRODUCT SEED DATA
            // ======================
            modelBuilder.Entity<Product>().HasData(

                // ===== CÀ PHÊ =====
                new Product
                {
                    Id = 1,
                    ProductName = "Cà phê đen",
                    Price = 25000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 2,
                    ProductName = "Cà phê sữa",
                    Price = 30000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 3,
                    ProductName = "Bạc xỉu",
                    Price = 35000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 4,
                    ProductName = "Latte",
                    Price = 45000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 5,
                    ProductName = "Cappuccino",
                    Price = 45000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 6,
                    ProductName = "Cà phê muối",
                    Price = 40000,
                    CategoryId = 1,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                // ===== TRÀ =====
                new Product
                {
                    Id = 7,
                    ProductName = "Trà đào cam sả",
                    Price = 45000,
                    CategoryId = 2,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 8,
                    ProductName = "Trà vải",
                    Price = 40000,
                    CategoryId = 2,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 9,
                    ProductName = "Trà sữa truyền thống",
                    Price = 45000,
                    CategoryId = 2,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 10,
                    ProductName = "Matcha Latte",
                    Price = 50000,
                    CategoryId = 2,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                // ===== NƯỚC ÉP =====
                new Product
                {
                    Id = 11,
                    ProductName = "Nước ép cam",
                    Price = 40000,
                    CategoryId = 3,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 12,
                    ProductName = "Sinh tố bơ",
                    Price = 50000,
                    CategoryId = 3,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 13,
                    ProductName = "Sinh tố xoài",
                    Price = 50000,
                    CategoryId = 3,
                    IsStockManaged = false,
                    StockQuantity = null,
                    IsAvailable = true,
                    IsDeleted = false
                },

                // ===== BÁNH NGỌT =====
                new Product
                {
                    Id = 14,
                    ProductName = "Bánh Tiramisu",
                    Price = 55000,
                    CategoryId = 4,
                    IsStockManaged = true,
                    StockQuantity = 10,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 15,
                    ProductName = "Croissant",
                    Price = 35000,
                    CategoryId = 4,
                    IsStockManaged = true,
                    StockQuantity = 15,
                    IsAvailable = true,
                    IsDeleted = false
                },

                // ===== ĐỒ ĂN VẶT =====
                new Product
                {
                    Id = 16,
                    ProductName = "Hướng dương",
                    Price = 20000,
                    CategoryId = 5,
                    IsStockManaged = true,
                    StockQuantity = 50,
                    IsAvailable = true,
                    IsDeleted = false
                },

                new Product
                {
                    Id = 17,
                    ProductName = "Khô gà lá chanh",
                    Price = 45000,
                    CategoryId = 5,
                    IsStockManaged = true,
                    StockQuantity = 30,
                    IsAvailable = true,
                    IsDeleted = false
                }
            );
        }
    }
}