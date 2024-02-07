using Data;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Models.Enums;

namespace VendedoresWebMvc.Data
{
    public class PopulacaoDeDados
    {
        //Instanciando uma classe do tipo VendoresWebMvcContext
        private VendedoresWebMvcContext _contexto;

        //Indicando que a inejeção de dependências irá acontecer quando uma PopulacaoDeDados for criada
        public PopulacaoDeDados(VendedoresWebMvcContext contexto) 
        {
            _contexto = contexto;
        }
        //Realizando a População de dados na data base
        public void PopulacaoDosDados() 
        {
            //Any verifica se existe algum registro nas tabelas caso tenha não irá acontecer nada
            if (_contexto.Departamento.Any() ||_contexto.RegistroDeVenda.Any() || _contexto.Vendedor.Any()) 
            {
                return;
            }
            //População do banco de dados
            Departamento d1 = new Departamento ( 1, "Computador");
            Departamento d2 = new Departamento(2, "Eletrônicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor s1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor s2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor s3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor s4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor s5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor s6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistrosDeVendas r1 = new RegistrosDeVendas(1, new DateTime(2024, 09, 25), 11000.0, StatusDaVenda.Faturado, s1);
            RegistrosDeVendas r2 = new RegistrosDeVendas(2, new DateTime(2024, 09, 4), 7000.0, StatusDaVenda.Faturado, s5);
            RegistrosDeVendas r3 = new RegistrosDeVendas(3, new DateTime(2024, 09, 13), 4000.0, StatusDaVenda.Cancelado, s4);
            RegistrosDeVendas r4 = new RegistrosDeVendas(4, new DateTime(2024, 09, 1), 8000.0, StatusDaVenda.Faturado, s1);
            RegistrosDeVendas r5 = new RegistrosDeVendas(5, new DateTime(2024, 09, 21), 3000.0, StatusDaVenda.Faturado, s3);
            RegistrosDeVendas r6 = new RegistrosDeVendas(6, new DateTime(2024, 09, 15), 2000.0, StatusDaVenda.Faturado, s1);
            RegistrosDeVendas r7 = new RegistrosDeVendas(7, new DateTime(2024, 09, 28), 13000.0, StatusDaVenda.Faturado, s2);
            RegistrosDeVendas r8 = new RegistrosDeVendas(8, new DateTime(2024, 09, 11), 4000.0, StatusDaVenda.Faturado, s4);
            RegistrosDeVendas r9 = new RegistrosDeVendas(9, new DateTime(2024, 09, 14), 11000.0, StatusDaVenda.Pedido, s6);
            RegistrosDeVendas r10 = new RegistrosDeVendas(10, new DateTime(2024, 09, 7), 9000.0, StatusDaVenda.Faturado, s6);
            RegistrosDeVendas r11 = new RegistrosDeVendas(11, new DateTime(2024, 09, 13), 6000.0, StatusDaVenda.Faturado, s2);
            RegistrosDeVendas r12 = new RegistrosDeVendas(12, new DateTime(2024, 09, 25), 7000.0, StatusDaVenda.Pedido, s3);
            RegistrosDeVendas r13 = new RegistrosDeVendas(13, new DateTime(2024, 09, 29), 10000.0, StatusDaVenda.Faturado, s4);
            RegistrosDeVendas r14 = new RegistrosDeVendas(14, new DateTime(2024, 09, 4), 3000.0, StatusDaVenda.Faturado, s5);
            RegistrosDeVendas r15 = new RegistrosDeVendas(15, new DateTime(2024, 09, 12), 4000.0, StatusDaVenda.Faturado, s1);
            RegistrosDeVendas r16 = new RegistrosDeVendas(16, new DateTime(2024, 10, 5), 2000.0, StatusDaVenda.Faturado, s4);
            RegistrosDeVendas r17 = new RegistrosDeVendas(17, new DateTime(2024, 10, 1), 12000.0, StatusDaVenda.Faturado, s1);
            RegistrosDeVendas r18 = new RegistrosDeVendas(18, new DateTime(2024, 10, 24), 6000.0, StatusDaVenda.Faturado, s3);
            RegistrosDeVendas r19 = new RegistrosDeVendas(19, new DateTime(2024, 10, 22), 8000.0, StatusDaVenda.Faturado, s5);
            RegistrosDeVendas r20 = new RegistrosDeVendas(20, new DateTime(2024, 10, 15), 8000.0, StatusDaVenda.Faturado, s6);
            RegistrosDeVendas r21 = new RegistrosDeVendas(21, new DateTime(2024, 10, 17), 9000.0, StatusDaVenda.Faturado, s2);
            RegistrosDeVendas r22 = new RegistrosDeVendas(22, new DateTime(2024, 10, 24), 4000.0, StatusDaVenda.Faturado, s4);
            RegistrosDeVendas r23 = new RegistrosDeVendas(23, new DateTime(2024, 10, 19), 11000.0, StatusDaVenda.Cancelado, s2);
            RegistrosDeVendas r24 = new RegistrosDeVendas(24, new DateTime(2024, 10, 12), 8000.0, StatusDaVenda.Faturado, s5);
            RegistrosDeVendas r25 = new RegistrosDeVendas(25, new DateTime(2024, 10, 31), 7000.0, StatusDaVenda.Faturado, s3);
            RegistrosDeVendas r26 = new RegistrosDeVendas(26, new DateTime(2024, 10, 6), 5000.0, StatusDaVenda.Faturado, s4);
            RegistrosDeVendas r27 = new RegistrosDeVendas(27, new DateTime(2024, 10, 13), 9000.0, StatusDaVenda.Pedido, s1);
            RegistrosDeVendas r28 = new RegistrosDeVendas(28, new DateTime(2024, 10, 7), 4000.0, StatusDaVenda.Faturado, s3);
            RegistrosDeVendas r29 = new RegistrosDeVendas(29, new DateTime(2024, 10, 23), 12000.0, StatusDaVenda.Faturado, s5);
            RegistrosDeVendas r30 = new RegistrosDeVendas(30, new DateTime(2024, 10, 12), 5000.0, StatusDaVenda.Faturado, s2);

            //Adicionando vários objetos com 'AddRange'
            _contexto.Departamento.AddRange(d1, d2, d3, d4);
            _contexto.Vendedor.AddRange(s1, s2, s3, s4, s5, s6);
            _contexto.RegistroDeVenda.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11,
                r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30);

            //Efetivando as operações no banco de Dados
            _contexto.SaveChanges();
        }
    }
}
