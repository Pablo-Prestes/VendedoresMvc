using Data;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Services.Exceptions;

namespace VendedoresWebMvc.Services
{
    public class VendedoresService
    {
        //Criando o contexto com o banco
        private readonly VendedoresWebMvcContext _context;

        //criando a dependência
        public VendedoresService(VendedoresWebMvcContext context) 
        {
            _context = context;
        }

        //Serviço para mostrar vendedores
        public async Task<List<Vendedor>> MostrarVendedores() 
        {
             return await _context.Vendedor.ToListAsync();
        }

        //Service para inserir vendedor
        public async Task Insert(Vendedor obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();         
        }
        //Service para modificar vendedor
        public async Task Update(Vendedor obj)
        {
            bool verifica = await _context.Vendedor.AnyAsync(x => x.Id == obj.Id);
            if (!verifica) 
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
        //Service para remover vendedor
        public async Task Remove(int id)
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }
        public async Task<Vendedor> ProcurarPorId(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }
       

    }
}   
