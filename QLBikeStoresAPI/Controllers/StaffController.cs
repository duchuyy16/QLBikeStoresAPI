using Microsoft.AspNetCore.Mvc;

namespace QLBikeStoresAPI.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
