using CafeManagement.Data;
using CafeManagement.Helpers;
using CafeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.Controllers
{
    public class PosController : Controller
    {
        private readonly CafeDbContext _context;

        public PosController(CafeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? tableId)
        {
            ViewBag.Tables = _context.CafeTables.ToList();

            ViewBag.Products = _context.Products
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.CategoryId)
                .ToList();

            ViewBag.SelectedTable = tableId;

            if (tableId != null)
            {
                string key = $"Cart_{tableId}";

                ViewBag.Cart = HttpContext.Session
                    .GetObject<List<CartItem>>(key)
                    ?? new List<CartItem>();
            }
            else
            {
                ViewBag.Cart = new List<CartItem>();
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddToCart(int tableId, int productId)
        {
            var product = _context.Products
                .FirstOrDefault(x => x.Id == productId);

            if (product == null)
                return RedirectToAction(nameof(Index));

            string key = $"Cart_{tableId}";

            var cart = HttpContext.Session
                .GetObject<List<CartItem>>(key);

            if (cart == null)
                cart = new List<CartItem>();

            var item = cart
                .FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else
            {
                item.Quantity++;
            }

            HttpContext.Session.SetObject(key, cart);

            // Cập nhật trạng thái bàn
            var table = _context.CafeTables
                .FirstOrDefault(x => x.Id == tableId);

            if (table != null)
            {
                table.Status = "Đang sử dụng";
            }

            // Cập nhật trạng thái đặt bàn
            var reservation = _context.Reservations
                .Where(x => x.TableId == tableId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            if (reservation != null &&
                reservation.Status == "Đã ")
            {
                reservation.Status = "Đang sử dụng";
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(Index),
                new { tableId });
        }

        [HttpPost]
        public IActionResult RemoveItem(
            int tableId,
            int productId)
        {
            string key = $"Cart_{tableId}";

            var cart = HttpContext.Session
                .GetObject<List<CartItem>>(key);

            if (cart == null)
                return RedirectToAction(nameof(Index),
                    new { tableId });

            var item = cart
                .FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                cart.Remove(item);
            }

            HttpContext.Session
                .SetObject(key, cart);

            return RedirectToAction(nameof(Index),
                new { tableId });
        }

        [HttpPost]
        public IActionResult Checkout(int tableId)
        {
            string key = $"Cart_{tableId}";

            var cart = HttpContext.Session
                .GetObject<List<CartItem>>(key);

            if (cart == null || !cart.Any())
            {
                return RedirectToAction(nameof(Index),
                    new { tableId });
            }

            var invoice = new Invoice
            {
                TableId = tableId,
                CreatedAt = DateTime.Now,
                Total = cart.Sum(x =>
                    x.Price * x.Quantity),
                Details = new List<InvoiceDetail>()
            };

            foreach (var item in cart)
            {
                invoice.Details.Add(
                    new InvoiceDetail
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
            }

            _context.Invoices.Add(invoice);
           
            
     
            var table = _context.CafeTables
                .FirstOrDefault(x => x.Id == tableId);

            if (table != null)
            {
                table.Status = "Trống";
            }

            _context.SaveChanges();

            
            HttpContext.Session.Remove(key);

            return RedirectToAction(
                "Details",
                "Invoice",
                new { id = invoice.Id });

       

        }

        public IActionResult TempInvoice(int tableId)
        {
            string key = $"Cart_{tableId}";

            var cart = HttpContext.Session
                .GetObject<List<CartItem>>(key)
                ?? new List<CartItem>();

            ViewBag.Table = _context.CafeTables
                .FirstOrDefault(x => x.Id == tableId);

            return View(cart);
        }
    }
}