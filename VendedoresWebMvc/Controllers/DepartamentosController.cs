using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Services;

namespace VendedoresWebMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly VendedoresWebMvcContext _context;
        private readonly DepartamentoService _departamentoService;

        public DepartamentosController(VendedoresWebMvcContext context, DepartamentoService departamentoService)
        {
            _context = context;
            _departamentoService = departamentoService;
        }

        // Get: Departamento
        public async Task<IActionResult> Index()
        {
              return _context.Departamento != null ? 
                          View(await _context.Departamento.ToListAsync()) :
                          Problem("Entity set 'VendedoresWebMvcContext.Departamento'  is null.");
        }

        // Get: detalhes do departamento
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // Get: Para criar departamentos
        public IActionResult Create()
        {
            return View();
        }

        // Post: para criar um departamento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {

                await _departamentoService.Insert(departamento);
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // Get:Para editar departamento
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }
        //Post: para editar departamento   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

        // Get: Departamentos
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departamento == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // Post:Para deletar vendedor
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departamento == null)
            {
                return Problem("Entity set 'VendedoresWebMvcContext.Departamento'  is null.");
            }

            await _departamentoService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartamentoExists(int id)
        {
          return (_context.Departamento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
