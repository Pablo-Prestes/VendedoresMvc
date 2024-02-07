using System;
using System.ComponentModel.DataAnnotations;

namespace VendedoresWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "campo nome não pode ser vazio")]
        [StringLength(15, MinimumLength =3, ErrorMessage ="o nome deve conter entre {2} e {1} caracteres")]
        public string Nome { get; set;}

        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();   

        public Departamento() { }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdiconarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }
        public double TotalVendas(DateTime inicial, DateTime final) 
        {
            return Vendedores.Sum(vendedor => vendedor.TotalDeVendasFiltrado(inicial, final));
        }
    }
}
