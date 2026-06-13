namespace CafeManagement.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }   // 🔥 BẮT BUỘC CÓ PRIMARY KEY

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}