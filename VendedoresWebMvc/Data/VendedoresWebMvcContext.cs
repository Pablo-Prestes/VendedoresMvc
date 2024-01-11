using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Models;

namespace VendedoresWebMvc.Data
{
    public class VendedoresWebMvcContext : DbContext
    {
        public VendedoresWebMvcContext (DbContextOptions<VendedoresWebMvcContext> options)
            : base(options)
        {
        }

        public DbSet<VendedoresWebMvc.Models.Departamento> Departamento { get; set; } = default!;
    }
}
