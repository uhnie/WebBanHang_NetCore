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

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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