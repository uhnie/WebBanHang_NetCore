namespace CafeManagement.ViewModels
{
    public class StatisticsViewModel
    {
        public decimal TodayRevenue { get; set; }

        public decimal MonthRevenue { get; set; }

        public decimal TotalRevenue { get; set; }

        public int InvoiceCount { get; set; }

        public int TotalProducts { get; set; }

        public int TotalTables { get; set; }

        public int TotalReservations { get; set; }

        public int TodayReservations { get; set; }

        public int ConfirmedReservations { get; set; }

        public int CancelledReservations { get; set; }

        public string MostUsedTable { get; set; } = "";

        public List<string> TopProductNames { get; set; } = new();

        public List<int> TopProductQuantities { get; set; } = new();

        public List<string> RevenueDays { get; set; } = new();

        public List<decimal> RevenueValues { get; set; } = new();
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}