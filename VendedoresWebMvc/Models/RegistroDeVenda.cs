using VendedoresWebMvc.Models.Enums;

namespace VendedoresWebMvc.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime DataDaVenda { get; set; }
        public double ValorDaVenda { get; set; }
        public StatusDaVenda StatusDaVenda { get; set; }

        public RegistroDeVenda() { }

        public RegistroDeVenda(int id, DateTime dataDaVenda, double valorDaVenda, StatusDaVenda statusDaVenda, Vendedor vendedor)
        {
           
            Id = id;
            DataDaVenda = dataDaVenda;
            ValorDaVenda = valorDaVenda;
            StatusDaVenda = statusDaVenda;
            Vendedor = vendedor;
        }
    }
}
