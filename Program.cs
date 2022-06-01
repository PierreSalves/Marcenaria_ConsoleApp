using System;
using System.IO;
using ExcelDataReader;

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
            do
            {
                Console.WriteLine("-------------------------------MARCENARIA MARCELUS-------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------Menu--------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("---------------------------- 1 Fazer pedido--------------------------------------");
                Console.WriteLine("-----------------------------2 Tabela de Clientes--------------------------------");
                
                Console.WriteLine("-----------------------------0 Sair----------------------------------------------");
                Console.WriteLine("");
                Console.Write("---------------------------- : ");
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        realizaPedido();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        Console.Write("Para sair digite 0 / Para voltar ao menu digite qualquer numero diferente de 0 : ");
                        menu = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                    {
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------------------------------------------------");
                        using (var documentosAntigos = File.Open("DataBase.xlsx", FileMode.Open, FileAccess.Read))
                        {
                            using (var planilha = ExcelReaderFactory.CreateReader(documentosAntigos))
                            {
                                try
                                {
                                    do
                                    {
                                        Console.WriteLine(planilha.Name);
                                        Console.WriteLine("---------------------------------------------------------------------------------");
                                        Console.WriteLine("Nome   |   Documento     |   Data de Nascimento   |" +
                                                          "      Telefone     |           Email          |    Cidade");
                                        while (planilha.Read())
                                        {
                                            Console.WriteLine(planilha.GetString(0) + "  |  " + planilha.GetString(1) + "  |  "
                                                              + planilha.GetDateTime(2) + "  |  " +
                                                              planilha.GetString(3) + "  |  "
                                                              + planilha.GetString(4) + "  |  " +
                                                              planilha.GetString(5));
                                        }
                                    } while (planilha.NextResult()); //Avança para a proxima linha da tabela
                                }                                    
                                catch (NullReferenceException)
                                {
                                    Console.WriteLine("---------------------------------------------------------------------------------");
                                    Console.Write("Para sair digite 0 / Para voltar ao menu digite qualquer numero diferente de 0 : ");
                                    menu = Convert.ToInt32(Console.ReadLine());
                                    documentosAntigos.Close();
                                    planilha.Close();
                                }
                                planilha.Close();
                            }
                            documentosAntigos.Close();
                        }
                        Console.WriteLine("");
                        Console.WriteLine("");
                        break;
                    }
                }
            } while (menu != 0);
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
            int portas = 0, gavetas = 0;
            string posicaoGavetas = "";
            switch (tipoMovel)
            {
                case "Armario" :
                    Console.Write("-------------- Informe a quantidade de portas do armario : ");
                    portas = Convert.ToInt32(Console.ReadLine());
                    moveis[0] = new Armario(portas);
                    pedido.movel = moveis[0];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(Verniz,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    pedido.movel.calculaPeso();
                    pedido.movel.calcularPreco();
                    break;
                case "Gaveteiro" :
                    Console.Write("-------------- Informe a quantidade de gavetas do gaveteiro : ");
                    gavetas = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a posicao das gavetas(vertical,horizontal): ");
                    posicaoGavetas = Console.ReadLine();
                    moveis[1] = new Gaveteiro(gavetas,posicaoGavetas);
                    pedido.movel = moveis[1];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(Verniz,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    pedido.movel.calculaPeso();
                    pedido.movel.calcularPreco();
                    break;
                case "Bancada" :
                    Console.WriteLine("-------------- Informe a quantidade de portas e gavetas e a posicao das gavetas na bancada---");
                    Console.Write("-------------- Quantidade de portas: ");
                    portas = Convert.ToInt32(Console.ReadLine()); 
                    Console.Write("-------------- Quantidade de gavetas: ");
                    gavetas = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Posicao das gavetas(vertical,horizontal): ");
                    posicaoGavetas = Console.ReadLine();
                    moveis[2] = new Bancada(portas,gavetas,posicaoGavetas);
                    pedido.movel = moveis[2];
                    Console.Write("-------------- Informe a altura desejada (cm): ");
                    pedido.movel.altura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a largura desejada (cm): ");
                    pedido.movel.largura = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe a profundidade desejada (cm): ");
                    pedido.movel.profundidade = Convert.ToInt32(Console.ReadLine());
                    Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                    pedido.movel.material = Console.ReadLine();
                    Console.Write("-------------- Informe a cor da bancada(Verniz,Marrom,Bege,Preto,Branco) : ");
                    pedido.movel.cor = Console.ReadLine();
                    pedido.movel.calculaPeso();
                    pedido.movel.calcularPreco();
                    break;
                default: 
                    Console.WriteLine("Informe um do tipo valido para movel");
                    break;
            }
            Console.Write("-------------- O local(cidade) de entrega(Aracatuba,Bastos,Tupa) : ");
            pedido.endereco_entrega = Console.ReadLine();
            Console.Write("-------------- O tipo de frete desejado(A retirar,Transportadora) : ");
            pedido.tipo_frete = Console.ReadLine();
            pedido.calcularPrazoFabricacao();
            pedido.calcularValorFrete();
            pedido.calcularValorTotal();
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Cliente : " + pedido.cliente.nome);
            Console.WriteLine("Data :" + pedido.data_pedido);
            Console.WriteLine("Tipo de Movel : " + pedido.movel.descricao);
            Console.WriteLine("Quantidade de Portas : " + portas);
            Console.WriteLine("Quantidade de Gavetas : " + gavetas);
            Console.WriteLine("Posicao das Gavetas : " + posicaoGavetas);
            Console.WriteLine("Altura : " + pedido.movel.altura + "cm");
            Console.WriteLine("Largura : " + pedido.movel.largura + "cm");
            Console.WriteLine("Profundidade : " + pedido.movel.profundidade + "cm");
            Console.WriteLine("Material : " + pedido.movel.material);
            Console.WriteLine("Cor : " + pedido.movel.cor);
            Console.WriteLine("Peso : " + pedido.movel.peso + "kg");
            Console.WriteLine("Prazo de Fabricacao : " + pedido.prazo_fabricacao);
            Console.WriteLine("Tipo de Frete : " + pedido.tipo_frete);
            Console.WriteLine("Dia da entrega : " + pedido.data_entrega);
            Console.WriteLine("Valor do Frete : R$" + pedido.valor_frete);
            Console.WriteLine("Preco do Movel : R$" + pedido.movel.preco);
            Console.WriteLine("Valor total : R$" + pedido.valor);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
    }
}