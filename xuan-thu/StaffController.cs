using CafeManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.Controllers
{
    public class StaffController : Controller
    {
        private readonly CafeDbContext _context;

        public StaffController(CafeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tables = _context.CafeTables.ToList();

            return View(tables);
        }
    }
}