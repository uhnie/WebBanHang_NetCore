using CafeManagement.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly CafeDbContext _context;

        public InvoiceController(CafeDbContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var invoice = _context.Invoices
                .Include(x => x.Table)
                .Include(x => x.Details)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);

            if (invoice == null)
                return NotFound();

            return View(invoice);
        }
    }
}