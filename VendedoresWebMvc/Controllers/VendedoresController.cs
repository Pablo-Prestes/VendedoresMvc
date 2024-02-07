using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Models.ViewModels;
using VendedoresWebMvc.Services;
using System.Diagnostics;

namespace VendedoresWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        //Injetando os services na classe   
        private readonly VendedoresService _vendedoresService;
        private readonly DepartamentoService _departamentoService;
        private readonly RegistrosDeVendasService _registrosDeVendasService;
        public VendedoresController(VendedoresService vendedoresService, DepartamentoService departamentoService, RegistrosDeVendasService registrosDeVendas)
        {
            _vendedoresService = vendedoresService;
            _departamentoService = departamentoService;
            _registrosDeVendasService = registrosDeVendas;
        }

        //Action para ver vendedores
        public async Task<IActionResult> Index()
        {
            var list = await _vendedoresService.MostrarVendedores();
            return View(list);
        }
        // Action para criar um novo vendedor
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.MostrarDepartamentos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        //Post: para criar o vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                var departamentos = await _departamentoService.MostrarDepartamentos();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedoresService.Insert(vendedor);
            return RedirectToAction(nameof(Index));

        }
        //Get: para deletar vendedor
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
        //Post: para deletar vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vendedoresService.Remove(id);
            return RedirectToAction("Index");
        }
        //Action para detalhes do vendedor
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
        //Get: para editar vendedor
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
        //Post: para editar vendedor
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
        //Get: Para total de vendas do vendedor
        public async Task<IActionResult> TotalDeVendas(int id)
        {
            var vendedor = await _vendedoresService.ProcurarPorId(id);
            var vendas = await _registrosDeVendasService.ProcurarPorVendedorId(id);
            var totalDeVendas = vendas.Sum(x => x.ValorDaVenda);

            var viewModel = new VendedorVendasViewModel
            {
                Vendedor = vendedor,
                Vendas = vendas,
                TotalDeVendas = totalDeVendas
            };

            return View(viewModel);
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
