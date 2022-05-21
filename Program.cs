using System;

namespace MarcenariaMarcelus
{
    internal static class Program
    {
        private static Cliente[] clientes = new Cliente[3];
        private static Movel[] moveis = new Movel[3];

        public static void Main(string[] args)
        {
            clientes[0] = new Cliente();
            clientes[0].nome = "Pierre Sanches Alves";
            clientes[0].CPF_CNPJ = "xxx.xxx.xxx-xx";
            clientes[0].data_nascimento = Convert.ToDateTime("1997-07-04");
            clientes[0].telefone = "(18)99141-5022";
            clientes[0].email = "040797pierre@gmail.com";
            clientes[0].endereco = "Aracatuba";
            /////////////////////////////////////////////////////////////
            clientes[1] = new Cliente();
            clientes[1].nome = "Ana Laura";
            clientes[1].CPF_CNPJ = "xxx.xxx.xxx-xx";
            clientes[1].data_nascimento = Convert.ToDateTime("2003-04-18");
            clientes[1].telefone = "(14)51541-7722";
            clientes[1].email = "ananunnes@gmail.com";
            clientes[1].endereco = "Tupa";
            /////////////////////////////////////////////////////////////
            clientes[2] = new Cliente();
            clientes[2].nome = "Matheus Amancio";
            clientes[2].CPF_CNPJ = "xxx.xxx.xxx-xx";
            clientes[2].data_nascimento = Convert.ToDateTime("2003-09-11");
            clientes[2].telefone = "(14)99751-1522";
            clientes[2].email = "matheusamancio@gmail.com";
            clientes[2].endereco = "Bastos";
            /////////////////////////////////////////////////////////////
            
            int menu;
            Console.WriteLine("-------------------------------MARCENARIA MARCELUS-------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------Menu--------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("---------------------------- 1 Fazer pedido--------------------------------------");
            Console.WriteLine("---------------------------- 2 Cadastrar Cliente---------------------------------");
            Console.WriteLine("");
                Console.Write("---------------------------- : ");
            menu = Convert.ToInt32(Console.ReadLine());
            if (menu == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------");
                realizaPedido();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------------------------------");
                informacaoPedido();
            }
            if (menu == 2)
            {
                /*try
                {
                    Cliente cliente = new Cliente();
                    StreamWriter tblCliente = new StreamWriter(
                        "C:/Users/pierr/Documents/Faculdade/V Semestre/C# - Fernando/MarcenariaMarcelus/Marcenaria_ConsoleApp/tabelaClientes.txt",
                        true, Encoding.UTF8);
                    
                    Console.Write("---Nome completo : ");
                    cliente.setNome(Console.In.ReadLine());
                    tblCliente.Write(cliente.getNome() + "---");

                    Console.Write("---CPF / CNPJ : ");
                    cliente.setCPF_CNPJ(Console.In.ReadLine());
                    tblCliente.Write(cliente.getCPF_CNPJ() + "---");

                    Console.Write("---Data de nascimento(yyyy-mm-dd) : ");
                    cliente.setDataNascimento(Convert.ToDateTime(Console.In.ReadLine()));
                    tblCliente.Write(cliente.getDataNascimento() + "---");

                    Console.Write("---Telefone : ");
                    cliente.setTelefone(Console.In.ReadLine());
                    tblCliente.Write(cliente.getTelefone() + "---");

                    Console.Write("---Email : ");
                    cliente.setEmail(Console.In.ReadLine());
                    tblCliente.Write(cliente.getEmail() + "---");

                    Console.Write("---Endereco : ");
                    cliente.setEndereco(Console.In.ReadLine());
                    tblCliente.WriteLine(cliente.getEndereco());
                    tblCliente.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }*/
            }
        }
        private static void realizaPedido()
        {
            Pedido pedido = new Pedido();
            Console.Write("-------------- Nome do Cliente : ");
            string nome = Console.ReadLine();
            switch (nome)
            {
                case "Pierre" :
                    pedido.cliente = clientes[0];
                    break;
                case "Ana" :
                    pedido.cliente = clientes[1];
                    break;
                case "Matheus" :
                    pedido.cliente = clientes[2];
                    break;
                default: 
                    Console.WriteLine("-------------- Informe um nome cadastrado");
                    break;
            }
            Console.Write("-------------- O tipo do movel desejado(Armario, Gaveteiro, Bancada) : ");
            string tipoMovel = Console.ReadLine();
            switch (tipoMovel)
            {
                case "Armario" :
                    Console.Write("-------------- Informe a quantidade de portas do armario : ");
                    moveis[0] = new Armario(Convert.ToInt32(Console.ReadLine()));
                    pedido.movel = moveis[0];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(SemCor,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    break;
                case "Gaveteiro" :
                    Console.Write("-------------- Informe a quantidade de gavetas do gaveteiro : ");
                    moveis[1] = new Gaveteiro(Convert.ToInt32(Console.ReadLine()));
                    pedido.movel = moveis[1];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(SemCor,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    pedido.movel.calculaPeso();
                    
                    break;
                case "Bancada" :
                    Console.WriteLine("-------------- Informe a quantidade de portas e gavetas da bancada---");
                    Console.Write("-------------- Quantidade de portas: ");
                    int portas = Convert.ToInt32(Console.ReadLine()); 
                    Console.Write("-------------- Quantidade de gavetas: ");
                    int gavetas = Convert.ToInt32(Console.ReadLine());
                    moveis[2] = new Bancada(portas,gavetas);
                    pedido.movel = moveis[2];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(SemCor,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    pedido.movel.calculaPeso();
                    break;
                default: 
                    Console.WriteLine("Informe um do tipo valido para movel");
                    break;
            }
            Console.Write("-------------- O local(cidade) de entrega(Aracatuba,Bastos,Tupa) : ");
            pedido.endereco_entrega = Console.ReadLine();
            
            Console.Write("-------------- O tipo de frete desejado(Retirar no Local,Transportadora) : ");
            pedido.tipo_frete = Console.ReadLine();
            pedido.calcularPrazoFabricacao();
            pedido.calcularValorFrete();
        }

        private static void informacaoPedido()
        {
            
        }
    }
}