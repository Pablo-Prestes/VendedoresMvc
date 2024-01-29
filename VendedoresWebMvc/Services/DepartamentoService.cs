using Data;
using VendedoresWebMvc.Models;

namespace VendedoresWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendedoresWebMvcContext _context;

        public DepartamentoService(VendedoresWebMvcContext context)
        {
            _context = context;
        }

        public List<Departamento> MostrarDepartamentos() 
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
    