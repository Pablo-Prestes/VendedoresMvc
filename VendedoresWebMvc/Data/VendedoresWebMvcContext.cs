using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VendedoresWebMvc.Models;

namespace Data
{
    public class VendedoresWebMvcContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VendedoresWebMvcContext(DbContextOptions<VendedoresWebMvcContext> options) : base(options)
        {
        }
 
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistrosDeVendas> RegistroDeVenda{ get; set; }
    }
}