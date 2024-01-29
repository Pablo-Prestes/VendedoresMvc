using Data;
using VendedoresWebMvc.Models;

namespace VendedoresWebMvc.Services
{
    public class VendedoresService
    {
        private readonly VendedoresWebMvcContext _context;

        public VendedoresService(VendedoresWebMvcContext context) 
        {
            _context = context;
        }

        public List<Vendedor> MostrarVendedores() 
        {
            return _context.Vendedor.ToList();
        }
    }
}
