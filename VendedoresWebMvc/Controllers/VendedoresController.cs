using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Models.ViewModels;
using VendedoresWebMvc.Services;

namespace VendedoresWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresService _vendedoresService;
        private readonly DepartamentoService _departamentoService;
        public VendedoresController(VendedoresService vendedoresService, DepartamentoService departamentoService) 
        {
            _vendedoresService = vendedoresService;
            _departamentoService = departamentoService;
        }
        public IActionResult Index()
        {
            var list = _vendedoresService.MostrarVendedores();         
            return View(list);
        }

        public IActionResult Create() 
        {
            var departamentos = _departamentoService.MostrarDepartamentos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _vendedoresService.Insert(vendedor);
            return RedirectToAction("Index");
        }
    }
}
