using Microsoft.AspNetCore.Mvc;

namespace QLBikeStoresAPI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
