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
        public float getAltura()
        {
            return (altura);
        }
        ///////////////////////////////////////////////////////
        public void setLargura(float largura)
        {
            this.largura = largura;
        }
        public float getLargura()
        {
            return (largura);
        }
        ///////////////////////////////////////////////////////
        public void setProfundidade(float profundidade)
        {
            this.profundidade = profundidade;
        }
        public float getProfundidade()
        {
            return (profundidade);
        }
        ///////////////////////////////////////////////////////
        public void setPeso(float peso)
        {
            this.peso = peso;
        }
        public float getPeso()
        {
            return (peso);
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