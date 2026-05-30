using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CafeManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên món không được để trống")]
        [StringLength(100)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Giá tiền không được để trống")]
        [Range(1000, 1000000,
            ErrorMessage = "Giá phải từ 1.000 đến 1.000.000")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? ImageUrl { get; set; }

        // Fixed the incorrect default value assignment
        public bool IsStockManaged { get; set; } = false;

        public int? StockQuantity { get; set; }

        public bool IsAvailable { get; set; } = true;


        public bool IsDeleted { get; set; } = false;

        // FOREIGN KEY
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        // NAVIGATION PROPERTY
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
    
}

