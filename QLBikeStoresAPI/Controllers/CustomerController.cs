using Microsoft.AspNetCore.Mvc;

namespace QLBikeStoresAPI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
