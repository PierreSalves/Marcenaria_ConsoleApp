namespace MarcenariaMarcelus
{
    public class Movel
    {
        public float altura;
        public float largura;
        public float profundidade;
        public float peso { get; private set; }
        public string cor;
        public string material;
        public float preco { get;protected set; }
        public string descricao { get; protected set; }
        public void calculaPeso()
        {
            switch (material)
            {
                case "Madeira Macica":  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
                    peso = (float)(((altura * largura * profundidade)/1000000)* 13.9); //resultado kg
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 9.3); //resultado kg
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    break;
            }
        }
    }
}