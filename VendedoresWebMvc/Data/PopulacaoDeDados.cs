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
            Departamento d2 = new Departamento(2, "Electronics");
            Departamento d3 = new Departamento(3, "Fashion");
            Departamento d4 = new Departamento(4, "Books");

            Vendedor s1 = new Vendedor(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Vendedor s2 = new Vendedor(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Vendedor s3 = new Vendedor(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Vendedor s4 = new Vendedor(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Vendedor s5 = new Vendedor(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Vendedor s6 = new Vendedor(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2018, 09, 25), 11000.0, StatusDaVenda.Faturado, s1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2018, 09, 4), 7000.0, StatusDaVenda.Faturado, s5);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2018, 09, 13), 4000.0, StatusDaVenda.Cancelado, s4);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2018, 09, 1), 8000.0, StatusDaVenda.Faturado, s1);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2018, 09, 21), 3000.0, StatusDaVenda.Faturado, s3);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2018, 09, 15), 2000.0, StatusDaVenda.Faturado, s1);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2018, 09, 28), 13000.0, StatusDaVenda.Faturado, s2);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2018, 09, 11), 4000.0, StatusDaVenda.Faturado, s4);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2018, 09, 14), 11000.0, StatusDaVenda.Pedido, s6);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2018, 09, 7), 9000.0, StatusDaVenda.Faturado, s6);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2018, 09, 13), 6000.0, StatusDaVenda.Faturado, s2);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2018, 09, 25), 7000.0, StatusDaVenda.Pedido, s3);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2018, 09, 29), 10000.0, StatusDaVenda.Faturado, s4);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2018, 09, 4), 3000.0, StatusDaVenda.Faturado, s5);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2018, 09, 12), 4000.0, StatusDaVenda.Faturado, s1);
            RegistroDeVenda r16 = new RegistroDeVenda(16, new DateTime(2018, 10, 5), 2000.0, StatusDaVenda.Faturado, s4);
            RegistroDeVenda r17 = new RegistroDeVenda(17, new DateTime(2018, 10, 1), 12000.0, StatusDaVenda.Faturado, s1);
            RegistroDeVenda r18 = new RegistroDeVenda(18, new DateTime(2018, 10, 24), 6000.0, StatusDaVenda.Faturado, s3);
            RegistroDeVenda r19 = new RegistroDeVenda(19, new DateTime(2018, 10, 22), 8000.0, StatusDaVenda.Faturado, s5);
            RegistroDeVenda r20 = new RegistroDeVenda(20, new DateTime(2018, 10, 15), 8000.0, StatusDaVenda.Faturado, s6);
            RegistroDeVenda r21 = new RegistroDeVenda(21, new DateTime(2018, 10, 17), 9000.0, StatusDaVenda.Faturado, s2);
            RegistroDeVenda r22 = new RegistroDeVenda(22, new DateTime(2018, 10, 24), 4000.0, StatusDaVenda.Faturado, s4);
            RegistroDeVenda r23 = new RegistroDeVenda(23, new DateTime(2018, 10, 19), 11000.0, StatusDaVenda.Cancelado, s2);
            RegistroDeVenda r24 = new RegistroDeVenda(24, new DateTime(2018, 10, 12), 8000.0, StatusDaVenda.Faturado, s5);
            RegistroDeVenda r25 = new RegistroDeVenda(25, new DateTime(2018, 10, 31), 7000.0, StatusDaVenda.Faturado, s3);
            RegistroDeVenda r26 = new RegistroDeVenda(26, new DateTime(2018, 10, 6), 5000.0, StatusDaVenda.Faturado, s4);
            RegistroDeVenda r27 = new RegistroDeVenda(27, new DateTime(2018, 10, 13), 9000.0, StatusDaVenda.Pedido, s1);
            RegistroDeVenda r28 = new RegistroDeVenda(28, new DateTime(2018, 10, 7), 4000.0, StatusDaVenda.Faturado, s3);
            RegistroDeVenda r29 = new RegistroDeVenda(29, new DateTime(2018, 10, 23), 12000.0, StatusDaVenda.Faturado, s5);
            RegistroDeVenda r30 = new RegistroDeVenda(30, new DateTime(2018, 10, 12), 5000.0, StatusDaVenda.Faturado, s2);

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
