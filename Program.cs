using System;
using System.IO;
using System.Text;

namespace MarcenariaMarcelus
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            int menu;
            
            Console.WriteLine("---MARCENARIA MARCELUS---");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("----------Menu-----------");
            Console.WriteLine("");
            Console.WriteLine("--- 1 Fazer pedido-------");
            Console.WriteLine("--- 2 Cadastrar Cliente--");
            Console.Write("--- : ");menu = Convert.ToInt32(Console.ReadLine());

            if (menu == 1)
            {
                realizaPedido();
            }
            
            if (menu == 2)
            {
                try
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
                    cliente.setDataNascimento(Convert.ToDateTime(Console.In.ReadLine().ToString()));
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

                    Console.WriteLine("Nome : " + cliente.getNome() + "CPF/CNPJ : " + cliente.getCPF_CNPJ());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
            }
        }

        private static void realizaPedido()
        {
            var tbl = new StreamReader("C:/Users/pierr/Documents/Faculdade/V Semestre/C# - Fernando/MarcenariaMarcelus/Marcenaria_ConsoleApp/tabelaClientes.txt");
            string linha;
            while ((linha = tbl.ReadLine()) != null)
            {
                Console.WriteLine(linha);
            }
            tbl.Close();
        }
    }
}