using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Models.ViewModels;
using VendedoresWebMvc.Services;
using System.Diagnostics;


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
        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresService.MostrarVendedores();
            return View(list);
        }
        // Cria a ação para criar
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.MostrarDepartamentos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        //Cria o vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (vendedor.Nome != null && vendedor.Departamento != null)
            {
                await _vendedoresService.Insert(vendedor);
                return RedirectToAction("Index");
            }
            else
                return BadRequest("Informe o vendedor");
        }
        //Criando a ação para a opção Deletar
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }
        //Deletando vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedoresService.Remove(id);
            return RedirectToAction("Index");
        }
        //Criando a ação para detalhes
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }
        //Criando a ação para Editar (Get)
        public async Task<IActionResult> Editar(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _vendedoresService.ProcurarPorId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            List<Departamento> departamentos = await _departamentoService.MostrarDepartamentos();
            VendedorFormViewModel viewModel = new() { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }
        //Editando vendedor(Post)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ids diferentes" });
            }
            try
            {
                await _vendedoresService.Update(vendedor);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)//Application exception é um supertipo e casa com NotFoundException e DbCocurrencyException
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }
        //Criando ação para as mensagens de erro personalizadas
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
