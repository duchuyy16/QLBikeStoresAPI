using Microsoft.AspNetCore.Mvc;

namespace QLBikeStoresAPI.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
