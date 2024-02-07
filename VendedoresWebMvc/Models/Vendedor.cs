using System;
using System.ComponentModel.DataAnnotations;

namespace VendedoresWebMvc.Models
{
    public class Vendedor
    {

        [Required(ErrorMessage ="campo nome não pode ser vazio!")]
        [StringLength(60,MinimumLength = 3, ErrorMessage ="O nome deve conter entre {2} e {1} caracteres")]
        public string Nome{ get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "campo e-mail não pode ser vazio!")]
        [EmailAddress(ErrorMessage ="email inválido")]
        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo aniversário não pode ser vazio!")]
        [Display(Name= "Dia do Aniversário")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DiaDoAniversario { get; set; }

        [Required(ErrorMessage = "campo salário não pode ser vazio!")]
        [Range(100.00, 50000.00, ErrorMessage = "o salário deve estar entre R${1} até R${2}")]
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

        public double TotalDeVendasFiltrado(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.DataDaVenda >= inicial && rv.DataDaVenda <= final).Sum(rv => rv.ValorDaVenda);
        }      
    }
}
