using CafeManagement.Models;

public class Invoice
{
    public int Id { get; set; }

    public int TableId { get; set; }
    public CafeTable Table { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal Total { get; set; }

    public List<InvoiceDetail> Details { get; set; }
}