namespace MarcenariaMarcelus
{
    public class Movel
    {
        protected float altura;
        protected float largura;
        protected float profundidade;
        protected float peso;
        protected string cor;
        protected string material;
        protected float preco;


         
        public void calcularPreco()
        {
        
        }
        ///////////////////////////////////////////////////////
        public void setAltura(float altura)
        {
            this.altura = altura;
        }
        public string getAltura()
        {
            return (altura);
        }
        ///////////////////////////////////////////////////////
        public void setLargura(float largura)
        {
            this.largura = largura;
        }
        public string getLargura()
        {
            return (largura);
        }
        ///////////////////////////////////////////////////////
        public void setProfundidade(float profundidade)
        {
            this.profundidade = profundidade;
        }
        public DateTime getProfundidade()
        {
            return (profundidade);
        }
        ///////////////////////////////////////////////////////
        public void setPeso(float peso)
        {
            this.peso = peso;
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
        public void setCor(string cor)
        {
            this.cor = cor;
        }
        public string getCor()
        {
            return (cor);
        }
        ///////////////////////////////////////////////////////
        public void setMaterial(string material)
        {
            this.material = material;
        }
        public string getMaterial()
        {
            return (material);
        }
    }
}