using Data;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Services.Exceptions;

namespace VendedoresWebMvc.Services
{
    public class VendedoresService
    {
        private readonly VendedoresWebMvcContext _context;

        public VendedoresService(VendedoresWebMvcContext context) 
        {
            _context = context;
        }

        public async Task<List<Vendedor>> MostrarVendedores() 
        {
             return await _context.Vendedor.ToListAsync();
        }

        public async Task Insert(Vendedor obj) 
        {
            //obj.Departamento = _context.Departamento.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();         
        }
        public async Task<Vendedor> ProcurarPorId(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }
        public async Task Remove(int id) 
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Vendedor obj)
        {
            bool verifica = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (verifica) 
            {
                throw new NotFoundExpection("Id não encontrado !");
            }
            
            try 
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}   
