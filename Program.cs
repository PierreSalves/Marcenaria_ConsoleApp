using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarcenariaMarcelus
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("---MARCENARIA MARCELUS---");
            Console.WriteLine("");
            Console.WriteLine("");
            List<Cliente> cadastroClientes = new List<Cliente>();
            try
            {
                Cliente cliente = new Cliente();
                StreamWriter tblCliente = new StreamWriter(
                    "C:/Users/pierr/Documents/Faculdade/V Semestre/C# - Fernando/MarcenariaMarcelus/Marcenaria_ConsoleApp/tabelaClientes.txt", true, Encoding.UTF8);
                Console.WriteLine("---Cadastrar Cliente---");

                Console.Write("---Nome completo : ");
                cliente.setNome(Console.In.ReadLine());
                tblCliente.Write(cliente.getNome() + "   ");

                Console.Write("---CPF / CNPJ : ");
                cliente.setCPF_CNPJ(Console.In.ReadLine());
                tblCliente.Write(cliente.getCPF_CNPJ() + "   ");

                /*Console.Write("---Data de nascimento(yyyyMMdd) : ");
                cliente.setDataNascimento(Console.In.ReadLine().ToString());
                tblCliente.Write(cliente.getDataNascimento() + "   ");*/

                Console.Write("---Telefone : ");
                cliente.setTelefone(Console.In.ReadLine());
                tblCliente.Write(cliente.getTelefone() + "   ");

                Console.Write("---Email : ");
                cliente.setEmail(Console.In.ReadLine());
                tblCliente.Write(cliente.getEmail() + "   ");

                Console.Write("---Endereco : ");
                cliente.setEndereco(Console.In.ReadLine());
                tblCliente.WriteLine(cliente.getEndereco() + "   ");

                tblCliente.Close();
                cadastroClientes.Add(cliente);

                Console.WriteLine("Nome : " + cliente.getNome() + "CPF/CNPJ : " + cliente.getCPF_CNPJ());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                Console.WriteLine(cadastroClientes);
            }


            
        }
        public void realizaPedido()
        {
                
        }
    }
}