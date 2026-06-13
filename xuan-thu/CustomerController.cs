using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
