namespace CafeManagement.Models
{
    public class CafeTable
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        // Trạng thái: "Trống" | "Đã đặt"
        public string Status { get; set; } = "Trống";
    }
}