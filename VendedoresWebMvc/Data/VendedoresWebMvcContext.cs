using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VendedoresWebMvc.Models;

namespace Data
{
    public class VendedoresWebMvcContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VendedoresWebMvcContext(DbContextOptions<VendedoresWebMvcContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("VendedoresWebMvcContext");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Departamento> Departamento { get; set; }
    }
}