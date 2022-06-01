namespace MarcenariaMarcelus
{
    public class Movel
    {
        public float altura;
        public float largura;
        public float profundidade;
        public float peso { get; protected set; }
        public string cor;
        public string material;
        public float preco { get;protected set; }
        public string descricao { get; protected set; }
    }
}