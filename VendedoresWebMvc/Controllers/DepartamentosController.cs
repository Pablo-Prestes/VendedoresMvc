using Microsoft.AspNetCore.Mvc;
using VendedoresWebMvc.Models;
using System.Collections.Concurrent;


namespace VendedoresWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> Lista = new List<Departamento>();
            Lista.Add(new Departamento { Id = 1, Nome = "Eletronicos" });
            Lista.Add(new Departamento { Id = 2, Nome = "Moda" });

            return View(Lista);
        }
    }
}
