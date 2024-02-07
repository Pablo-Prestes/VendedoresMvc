using Data;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Models;

namespace VendedoresWebMvc.Services
{
    public class RegistrosDeVendasService
    {
        private readonly VendedoresWebMvcContext _context;

        public RegistrosDeVendasService(VendedoresWebMvcContext context) 
        {
            _context = context;
        }

        public async Task<List<RegistrosDeVendas>> ProcurarPorData(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.RegistroDeVenda select obj;
            if (minDate.HasValue) 
            {
                result = result.Where(x => x.DataDaVenda >= minDate.Value);
            }
            if (maxDate.HasValue) 
            {
                result = result.Where(x => x.DataDaVenda <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataDaVenda)
                .ToListAsync();           
        }

        public async Task<List<IGrouping<Departamento,RegistrosDeVendas>>> ProcurarPorGrupo(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.RegistroDeVenda select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.DataDaVenda >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.DataDaVenda <= maxDate.Value);
            }
            return await result
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.DataDaVenda)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
        public async Task<List<RegistrosDeVendas>> ProcurarPorVendedorId(int vendedorId)
        {
            return await _context.RegistroDeVenda
                .Where(x => x.Vendedor.Id == vendedorId)
                .Include(x => x.Vendedor)
                .OrderByDescending(x => x.DataDaVenda)
                .ToListAsync();
        }
    }
}
