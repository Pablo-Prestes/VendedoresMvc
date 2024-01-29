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
        
        public IActionResult Delete(int? Id) 
        {
            if (Id == null) 
            {
                return NotFound();
            }
            var obj = _vendedoresService.MostrarPorId(Id.Value);
            if(obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) 
        {
            _vendedoresService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
