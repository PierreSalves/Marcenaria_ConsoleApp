namespace MarcenariaMarcelus
{
    public class Bancada : Movel
    {
        public int portas { get; }
        public int gavetas { get; }
        
        public Bancada(int _portas,int _gavetas)
        {
            portas = _portas;
            gavetas = _gavetas;
            descricao = "Bancada";
        }
        public void calcularPreco()  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
        {
            switch (material)
            {
                case "Madeira Macica":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5) + (gavetas * 1.3)) * 320);  
                    //preco = (m³+ portas150% + gavetas130%) * R$ 320,00
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5) + (gavetas * 1.3)) * 200);  
                    //preco = (m³ + portas150% + gavetas130%) * R$ 200,00
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5) + (gavetas * 1.3)) * 150);  
                    //preco = (m³ + portas150% + gavetas130%) * R$ 150,00
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5) + (gavetas * 1.3)) * 150);  
                    //preco = (m³ + portas150% + gavetas130%) * R$ 150,00
                    break;
            }
        }
    }
}