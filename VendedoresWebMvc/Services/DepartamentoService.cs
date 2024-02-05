using Data;
using VendedoresWebMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace VendedoresWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendedoresWebMvcContext _context;

        public DepartamentoService(VendedoresWebMvcContext context)
        {
            _context = context;
        }

        public async Task <List<Departamento>>MostrarDepartamentos()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
   