using Microsoft.AspNetCore.Mvc;

namespace QLBikeStoresAPI.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
