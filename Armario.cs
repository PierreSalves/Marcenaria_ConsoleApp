namespace MarcenariaMarcelus
{
    public class Armario : Movel
    {
        
        public int portas { get; }

        public Armario(int portas)
        {
            this.portas = portas;
            descricao = "Armario";
            calcularPreco();
        }
        public void calcularPreco()  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
        {
            switch (material)
            {
                case "Madeira Macica":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 320);  
                    //preco = (m³ + 150%portas) * R$ 320,00
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 200);  
                    //preco = (m³ + 150%portas) * R$ 200,00
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 150);  
                    //preco = (m³+ 150%portas) * R$ 150,00
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 150);  
                    //preco = (m³ + 150%portas) * R$ 150,00
                    break;
            }
        }
    }
}