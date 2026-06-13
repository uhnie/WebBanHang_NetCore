using CafeManagement.Data;
using CafeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly CafeDbContext _context;

        public StatisticsController(CafeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(
            DateTime? fromDate,
            DateTime? toDate)
        {
            var model = new StatisticsViewModel();

            var today = DateTime.Today;

            // Query hóa đơn dùng cho bộ lọc
            var invoices = _context.Invoices
                .Include(x => x.Table)
                .AsQueryable();

            if (fromDate.HasValue)
            {
                invoices = invoices.Where(x =>
                    x.CreatedAt.Date >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                invoices = invoices.Where(x =>
                    x.CreatedAt.Date <= toDate.Value.Date);
            }

            // Doanh thu hôm nay
            model.TodayRevenue =
                _context.Invoices
                .Where(x => x.CreatedAt.Date == today)
                .Sum(x => (decimal?)x.Total) ?? 0;

            // Doanh thu tháng
            model.MonthRevenue =
                _context.Invoices
                .Where(x =>
                    x.CreatedAt.Month == DateTime.Now.Month &&
                    x.CreatedAt.Year == DateTime.Now.Year)
                .Sum(x => (decimal?)x.Total) ?? 0;

            // Doanh thu theo bộ lọc
            model.TotalRevenue =
                invoices.Sum(x => (decimal?)x.Total) ?? 0;

            // Tổng hóa đơn theo bộ lọc
            model.InvoiceCount =
                invoices.Count();

            // Tổng sản phẩm
            model.TotalProducts =
                _context.Products.Count();

            // Tổng bàn
            model.TotalTables =
                _context.CafeTables.Count();

            // Tổng đặt bàn
            model.TotalReservations =
                _context.Reservations.Count();

            // Đặt bàn hôm nay
            model.TodayReservations =
                _context.Reservations
                .Count(x => x.ReservationTime.Date == today);

            // Đã đặt
            model.ConfirmedReservations =
                _context.Reservations
                .Count(x => x.Status == "Đã đặt");

            // Đã hủy
            model.CancelledReservations =
                _context.Reservations
                .Count(x => x.Status == "Đã hủy");

            // Bàn được sử dụng nhiều nhất
            model.MostUsedTable =
                invoices
                .GroupBy(x => x.Table.TableName)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault() ?? "Chưa có";

            // TOP 5 món bán chạy theo khoảng thời gian
            var topProducts =
                _context.InvoiceDetails
                .Include(x => x.Product)
                .Include(x => x.Invoice)
                .Where(x =>
                    (!fromDate.HasValue ||
                     x.Invoice.CreatedAt.Date >= fromDate.Value.Date)
                    &&
                    (!toDate.HasValue ||
                     x.Invoice.CreatedAt.Date <= toDate.Value.Date))
                .GroupBy(x => x.Product.ProductName)
                .Select(x => new
                {
                    Name = x.Key,
                    Quantity = x.Sum(y => y.Quantity)
                })
                .OrderByDescending(x => x.Quantity)
                .Take(5)
                .ToList();

            model.TopProductNames =
                topProducts.Select(x => x.Name).ToList();

            model.TopProductQuantities =
                topProducts.Select(x => x.Quantity).ToList();

            // Biểu đồ doanh thu
            var revenueChart =
                invoices
                .GroupBy(x => x.CreatedAt.Date)
                .Select(x => new
                {
                    Date = x.Key,
                    Revenue = x.Sum(y => y.Total)
                })
                .OrderBy(x => x.Date)
                .ToList();

            model.RevenueDays =
                revenueChart
                .Select(x => x.Date.ToString("dd/MM"))
                .ToList();

            model.RevenueValues =
                revenueChart
                .Select(x => x.Revenue)
                .ToList();

            // Lưu lại ngày đã chọn
            model.FromDate = fromDate;
            model.ToDate = toDate;

            return View(model);
        }
    }
}