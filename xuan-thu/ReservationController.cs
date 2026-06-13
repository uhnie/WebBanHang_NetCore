using CafeManagement.Data;
using CafeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Controllers.Staff
{
    public class ReservationController : Controller
    {
        private readonly CafeDbContext _context;

        public ReservationController(CafeDbContext context)
        {
            _context = context;
        }

        // DANH SÁCH ĐẶT BÀN
        public IActionResult Index()
        {
            var data = _context.Reservations
                .Include(x => x.Table)
                .OrderByDescending(x => x.Id)
                .ToList();

            return View(data);
        }
        public IActionResult Pending()
        {
            var data = _context.Reservations
                .Include(x => x.Table)
                .Where(x => x.Status == "Pending")
                .OrderByDescending(x => x.Id)
                .ToList();

            return View(data);
        }
       
   
        [HttpGet]
        
        public IActionResult CustomerCreate()
        {
            var role = HttpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(role))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Tables = _context.CafeTables
                .Where(x => !_context.Reservations.Any(r =>
                    r.TableId == x.Id &&
                    (r.Status == "Pending" ||
                     r.Status == "Confirmed")))
                .ToList();

            return View();
        }
        // LƯU ĐẶT BÀN
        [HttpPost]
        public IActionResult CustomerCreate(Reservation model)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Tables = _context.CafeTables
                    .Where(x => x.Status == "Trống")
                    .ToList();

                return View(model);
            }

            model.Status = "Pending";

            _context.Reservations.Add(model);
            _context.SaveChanges();

            TempData["Success"] =
                "Đặt bàn thành công. Chờ nhân viên xác nhận.";

            return RedirectToAction("CustomerCreate");
        }


        [HttpPost]
        public IActionResult Confirm(int id)
        {
            var reservation = _context.Reservations
                .FirstOrDefault(x => x.Id == id);

            if (reservation == null)
                return NotFound();

            reservation.Status = "Confirmed";

            _context.SaveChanges();

            return RedirectToAction(nameof(Pending));
        }


        [HttpPost]

        public IActionResult Create(Reservation reservation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Tables = _context.CafeTables
        .Where(x => x.Status == null || x.Status == "Trống")
        .ToList();

                    return View(reservation);
                }

                reservation.Status = "Confirmed";

                _context.Reservations.Add(reservation);

         

                _context.SaveChanges();

                TempData["Success"] =
                    "Đặt bàn thành công";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
        [HttpPost]
        public IActionResult Complete(int id)
        {
            var reservation = _context.Reservations
                .FirstOrDefault(x => x.Id == id);

            if (reservation == null)
                return NotFound();

            reservation.Status = "Completed";

            _context.SaveChanges();

            TempData["Success"] = "Đã hoàn thành đặt bàn";

            return RedirectToAction(nameof(Index));
        }
        // CHI TIẾT ĐẶT BÀN
        public IActionResult Details(int id)
        {
            var reservation = _context.Reservations
                .Include(x => x.Table)
                .FirstOrDefault(x => x.Id == id);

            if (reservation == null)
                return NotFound();

            return View(reservation);
        }
    }
}