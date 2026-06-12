using System.ComponentModel.DataAnnotations;
namespace CafeManagement.Models
{
    public class CafeTable
    {
            public int Id { get; set; }

            [Required]
            [Display(Name = "Tên bàn")]
            public string TableName { get; set; }

            [Display(Name = "Trạng thái")]
            public bool IsOccupied { get; set; }
        }
    
}
