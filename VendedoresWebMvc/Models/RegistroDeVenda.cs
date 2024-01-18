namespace VendedoresWebMvc.Models
{
    public class RegistroDeVenda
    {
        public  Vendedor Vendedor { get; set; }
        public int Id { get; set; }
        public DateTime DataDaVenda { get; set; }
        public double ValorDaVenda { get; set; }
        //public Vendedor StatusDaVenda { get; set; }

        public RegistroDeVenda() { }

        public RegistroDeVenda(Vendedor vendedor, int id, DateTime dataDaVenda, double valorDaVenda /*Vendedor statusDaVenda*/)
        {
            Vendedor = vendedor;
            Id = id;
            DataDaVenda = dataDaVenda;
            ValorDaVenda = valorDaVenda;
            //StatusDaVenda = statusDaVenda;
        }
    }
}
