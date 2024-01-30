using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Models.ViewModels;
using VendedoresWebMvc.Services;
using VendedoresWebMvc.Services.Exceptions;

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
        //Criando a ação para a opção Deletar
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Deletando vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _vendedoresService.Remove(id);
            return RedirectToAction("Index");
        }
        //Criando a ação para detalhes
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //Criando a ação para Editar
        public IActionResult Editar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Departamento> departamentos = _departamentoService.MostrarDepartamentos();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }
        //Deletando vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }
            try { 
            _vendedoresService.Update(vendedor);
            return RedirectToAction("Index");
            }
            catch (NotFoundExpection ex)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
