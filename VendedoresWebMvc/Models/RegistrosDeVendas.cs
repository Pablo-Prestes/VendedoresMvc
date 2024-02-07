using System.ComponentModel.DataAnnotations;
using VendedoresWebMvc.Models.Enums;

namespace VendedoresWebMvc.Models
{
    public class RegistrosDeVendas
    {
        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        [Display(Name="Data da Venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataDaVenda { get; set; }
    
        [Display(Name = "Valor da Venda")]
        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode = true)]
        public double ValorDaVenda { get; set; }

        [Display(Name ="Status")]
        public StatusDaVenda StatusDaVenda { get; set; }

        public RegistrosDeVendas() { }

        public RegistrosDeVendas(int id, DateTime dataDaVenda, double valorDaVenda, StatusDaVenda statusDaVenda, Vendedor vendedor)
        {           
            Id = id;
            DataDaVenda = dataDaVenda;
            ValorDaVenda = valorDaVenda;
            StatusDaVenda = statusDaVenda;
            Vendedor = vendedor;
        }
    }
}
