using System;
using System.ComponentModel.DataAnnotations;

namespace VendedoresWebMvc.Models
{
    public class Vendedor
    {
  

        public string Nome{ get; set; }
        public int Id { get; set; }

        [Display(Name ="E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name= "Dia do Aniversário")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DiaDoAniversario { get; set; }

        [Display(Name ="Salário Bruto")]
       
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>();    
        
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

        public void AdicionarVenda(RegistroDeVenda registroDeVenda) 
        {
            Vendas.Add(registroDeVenda);
        }
        public void RemoverVenda(RegistroDeVenda registroDeVenda) 
        {
            Vendas.Remove(registroDeVenda);
        }

        public double TotalDeVendas(DateTime inicial, DateTime final)
        {
            return Vendas.Where(rv => rv.DataDaVenda >= inicial && rv.DataDaVenda <= final).Sum(rv => rv.ValorDaVenda);
        }
    }
}
