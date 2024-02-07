namespace VendedoresWebMvc.Models.ViewModels
{
    public class VendedorVendasViewModel
    {
        public Vendedor Vendedor { get; set; }
        public List<RegistrosDeVendas> Vendas { get; set; }

        public double TotalDeVendas { get; set; }
    }
}