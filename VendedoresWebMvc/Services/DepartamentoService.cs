using Data;
using VendedoresWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Services.Exceptions;

namespace VendedoresWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly VendedoresWebMvcContext _context;

        public DepartamentoService(VendedoresWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> MostrarDepartamentos()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
        //Serviço para inserir departamento
        public async Task Insert(Departamento obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        //Serviço para deletar departamento
        public async Task Remove(int id) 
        {
            var obj = await _context.Departamento.FindAsync(id);
            _context.Departamento.Remove(obj);
            await _context.SaveChangesAsync();
        }
        //Serviço para editar departamento
        public async Task Update(Departamento obj) 
        {
            bool verifica = await _context.Departamento.AnyAsync(x => x.Id == obj.Id);
            if (!verifica)
            {
                throw new NotFoundExpection("Id não encontrado !");
            }
            try 
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException e)
                {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
   