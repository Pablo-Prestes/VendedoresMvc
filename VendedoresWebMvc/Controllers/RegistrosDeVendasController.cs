using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Services;

namespace VendedoresWebMvc.Controllers
{
    public class RegistrosDeVendasController : Controller
    {
        private readonly RegistrosDeVendasService _registrosDeVendasService;

        public RegistrosDeVendasController(RegistrosDeVendasService registrosDeVendasService)
        {
            _registrosDeVendasService = registrosDeVendasService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Periodo(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 11, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _registrosDeVendasService.ProcurarPorData(minDate, maxDate);
            return View(result);
        }
        public async Task<IActionResult> Departamento(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 11, 1);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _registrosDeVendasService.ProcurarPorGrupo(minDate, maxDate);
            return View(result);
        }
    }
}

