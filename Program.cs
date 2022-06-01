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
            bool continuarComprando = true;
            int portas, gavetas;
            string posicaoGavetas;
            
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
            do
            {
                Console.Write("-------------- O tipo do movel desejado(Armario, Gaveteiro, Bancada) : ");
                string tipoMovel = Console.ReadLine();
                portas = 0; gavetas = 0;
                float altura = 0, largura = 0, profundidade = 0;
                string material = "", cor = ""; posicaoGavetas = "";
                switch (tipoMovel)
                {
                    case "Armario":
                        Console.Write("-------------- Informe a altura desejada (cm): ");
                        altura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a largura desejada (cm): ");
                        largura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a profundidade desejada (cm): ");
                        profundidade = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a quantidade de portas do armario : ");
                        portas = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe o material do armario(Madeira Macica,MDF,Compensado) : ");
                        material = Console.ReadLine();
                        Console.Write("-------------- Informe a cor do armario(Verniz,Marrom,Bege,Preto,Branco) : ");
                        cor = Console.ReadLine();
                        pedido.moveis.Add(new Armario(altura,largura,profundidade,material,cor,portas));
                        break;
                    case "Gaveteiro" :
                        Console.Write("-------------- Informe a altura desejada (cm): ");
                        altura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a largura desejada (cm): ");
                        largura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a profundidade desejada (cm): ");
                        profundidade = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a quantidade de gavetas do gaveteiro : ");
                        gavetas = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a posicao das gavetas(vertical,horizontal): ");
                        posicaoGavetas = Console.ReadLine();
                        Console.Write("-------------- Informe o material do gaveteiro(Madeira Macica,MDF,Compensado) : ");
                        material = Console.ReadLine();
                        Console.Write("-------------- Informe a cor do gaveteiro(Verniz,Marrom,Bege,Preto,Branco) : ");
                        cor = Console.ReadLine();
                        pedido.moveis.Add(new Gaveteiro(altura,largura,profundidade,material,cor,gavetas,posicaoGavetas));
                        break;
                    case "Bancada" :
                        Console.Write("-------------- Informe a altura desejada (cm): ");
                        altura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a largura desejada (cm): ");
                        largura = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Informe a profundidade desejada (cm): ");
                        profundidade = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-------------- Informe a quantidade de portas e gavetas e a posicao das gavetas na bancada---");
                        Console.Write("-------------- Quantidade de portas: ");
                        portas = Convert.ToInt32(Console.ReadLine()); 
                        Console.Write("-------------- Quantidade de gavetas: ");
                        gavetas = Convert.ToInt32(Console.ReadLine());
                        Console.Write("-------------- Posicao das gavetas(vertical,horizontal): ");
                        posicaoGavetas = Console.ReadLine();
                        Console.Write("-------------- Informe o material da bancada(Madeira Macica,MDF,Compensado) : ");
                        material = Console.ReadLine();
                        Console.Write("-------------- Informe a cor da bancada(Verniz,Marrom,Bege,Preto,Branco) : ");
                        cor = Console.ReadLine();
                        pedido.moveis.Add(new Bancada(altura,largura,profundidade,material,cor,portas,gavetas,posicaoGavetas));
                        break;
                    default:
                        Console.WriteLine("Informe um do tipo valido para movel");
                        break;
                }
                Console.WriteLine("---------------------------------------------------------------------------------");
                Console.Write("Deseja incluir outro movel?(S / N) : ");
                char confirma = Convert.ToChar(Console.ReadLine());
                if (confirma == 'N' || confirma == 'n')
                {
                    continuarComprando = false;
                }
                Console.WriteLine("---------------------------------------------------------------------------------");
            } while (continuarComprando);
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
            Console.WriteLine("Itens ---------------");
            foreach (var movel in pedido.moveis)
            {
                Console.WriteLine("---Tipo de movel: {0}",movel.descricao);
                Console.WriteLine("---Altura: {0}cm",movel.altura);
                Console.WriteLine("---Largura: {0}cm",movel.largura);
                Console.WriteLine("---Profundidade: {0}cm",movel.profundidade);
                Console.WriteLine("---Quantidade de Portas : {0}",portas);
                Console.WriteLine("---Quantidade de Gavetas : {0}",gavetas);
                Console.WriteLine("---Posicao das Gavetas : {0}",posicaoGavetas);
                Console.WriteLine("Material :{0}",movel.material);
                Console.WriteLine("Cor : {0}",movel.cor);
                Console.WriteLine("Peso : {0}kg",movel.peso);
            }
            Console.WriteLine("Prazo de Fabricacao : " + pedido.prazo_fabricacao);
            Console.WriteLine("Tipo de Frete : " + pedido.tipo_frete);
            Console.WriteLine("Dia da entrega : " + pedido.data_entrega);
            Console.WriteLine("Valor do Frete : R$" + pedido.valor_frete);
            Console.WriteLine("Valor total : R$" + pedido.valor);
            Console.WriteLine("---------------------------------------------------------------------------------");
            
        }
    }
}