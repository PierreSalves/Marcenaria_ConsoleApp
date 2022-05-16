using System;

namespace MarcenariaMarcelus
{
    public class Cliente
    {
        private string nome;
        private string CPF_CNPJ;
        private DateTime data_nascimento;
        private string telefone;
        private string email;
        private string endereco;


        ///////////////////////////////////////////////////////
        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return(nome);
        }
        ///////////////////////////////////////////////////////
        public void setCPF_CNPJ(string CPF_CNPJ)
        {
            this.CPF_CNPJ = CPF_CNPJ;
        }
        public string getCPF_CNPJ()
        {
            return(CPF_CNPJ);
        }
        ///////////////////////////////////////////////////////
        public void setDataNascimento(DateTime data_nascimento)
        {
            this.data_nascimento = data_nascimento;
        }
        public DateTime getDataNascimento()
        {
            return (data_nascimento);
        }
        ///////////////////////////////////////////////////////
        public void setTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public string getTelefone()
        {
            return (telefone);
        }
        ///////////////////////////////////////////////////////
        public void setEmail(string email)
        {
            this.email = email;
        }
        public string getEmail()
        {
            return (email);
        }
        ///////////////////////////////////////////////////////
        public void setEndereco(string endereco)
        {
            this.endereco = endereco;
        }
        public string getEndereco()
        {
            return (endereco);
        }
    }
}