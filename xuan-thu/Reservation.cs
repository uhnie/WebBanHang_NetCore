using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeManagement.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bàn")]
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public CafeTable? Table { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thời gian đặt")]
        public DateTime ReservationTime { get; set; }

        public string Status { get; set; } = "Pending";
    }
}