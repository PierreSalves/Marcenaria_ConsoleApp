namespace MarcenariaMarcelus
{
    public class Gaveteiro : Movel
    {
        public int gavetas { get; }
        public Gaveteiro(int _gavetas)
        {
            gavetas = _gavetas;
            descricao = "Gaveteiro";
        }
        public void calcularPreco()  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
        {
            switch (material)
            {
                case "Madeira Macica":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 320);  
                    //preco = (m³ + gavetas130%) * R$ 320,00
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 200);  
                    //preco = (m³ + gavetas130%) * R$ 200,00
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 150);  
                    //preco = (m³ + gavetas130%) * R$ 150,00
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 150);  
                    //preco = (m³ + gavetas130%) * R$ 150,00
                    break;
            }
        }
    }
}