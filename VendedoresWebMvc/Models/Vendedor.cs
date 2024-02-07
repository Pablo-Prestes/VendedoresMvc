using System;
using System.ComponentModel.DataAnnotations;

namespace VendedoresWebMvc.Models
{
    public class Vendedor
    {

        [Required(ErrorMessage ="Precisa ter um {0}")]
        [StringLength(60,MinimumLength = 3, ErrorMessage ="O {0} deve conter entre {2} e {1} caracteres")]
        public string Nome{ get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Precisa ter um {0}")]
        [EmailAddress(ErrorMessage ="Digite um e-mail válido")]
        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Precisa ter um {0}")]
        [Display(Name= "Dia do Aniversário")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DiaDoAniversario { get; set; }

        [Required(ErrorMessage = "Precisa ter um {0}")]
        [Range(100.00, 50000.00, ErrorMessage ="O {0} precisa estar entre {1} à {2}")]
        [Display(Name ="Salário Bruto")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistrosDeVendas> Vendas { get; set; } = new List<RegistrosDeVendas>();    
        
        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime diaDoAniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;        
            Email = email;
            DiaDoAniversario = diaDoAniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVenda(RegistrosDeVendas registroDeVenda) 
        {
            Vendas.Add(registroDeVenda);
        }
        public void RemoverVenda(RegistrosDeVendas registroDeVenda) 
        {
            Vendas.Remove(registroDeVenda);
        }

        public double TotalDeVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.DataDaVenda >= inicial && rv.DataDaVenda <= final).Sum(rv => rv.ValorDaVenda);
        }
    }
}
