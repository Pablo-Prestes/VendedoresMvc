using Microsoft.AspNetCore.Mvc;

namespace VendedoresWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
