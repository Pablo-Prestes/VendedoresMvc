using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Services;

namespace VendedoresWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresService _vendedoresService;

        public VendedoresController(VendedoresService vendedoresService) 
        {
            _vendedoresService = vendedoresService;
        }
        public IActionResult Index()
        {
            var list = _vendedoresService.MostrarVendedores();
            
            return View(list);
        }
    }
}
