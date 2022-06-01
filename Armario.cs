namespace MarcenariaMarcelus
{
    public class Armario : Movel
    {
        public int portas { get; }
        public Armario(float altura,float largura,float profundidade,string material,string cor,int portas)
        {
            this.portas = portas;
            this.altura = altura;
            this.largura = largura;
            this.profundidade = profundidade;
            this.material = material;
            this.cor = cor;
            descricao = "Armario";
            switch (material)
            {
                case "Madeira Macica":  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
                    peso = (float)(((altura * largura * profundidade)/1000000)* 13.9); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 320);  
                    //resultado => preco = (m³ + 150%portas) * R$ 320,00
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 9.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 200);  
                    //resultado => preco = (m³ + 150%portas) * R$ 200,00
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 150);  
                    //resultado => preco = (m³+ 150%portas) * R$ 150,00
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    this.material = "MDF";
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (portas * 1.5)) * 150);  
                    //resultado => preco = (m³ + 150%portas) * R$ 150,00
                    break;
            }
        }
    }
}