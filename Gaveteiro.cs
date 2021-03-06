namespace MarcenariaMarcelus
{
    public class Gaveteiro : Movel
    {
        public int gavetas { get; }
        public string posicaoGavetas { get; }
        public Gaveteiro(float altura,float largura,float profundidade,string material,string cor,int gavetas,string posicaoGavetas)
        {
            this.gavetas = gavetas;
            this.posicaoGavetas = posicaoGavetas;
            this.altura = altura;
            this.largura = largura;
            this.profundidade = profundidade;
            this.material = material;
            this.cor = cor;
            descricao = "Gaveteiro";
            switch (material)
            {
                case "Madeira Macica":  //medidas chegam em cm entao foi convertido em m³ (altura*largura*profundidade)/ 1.000.000)
                    peso = (float)(((altura * largura * profundidade)/1000000)* 13.9); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 320);  
                    //resultado => preco = (m³ + gavetas130%) * R$ 320,00
                    break;
                case "MDF":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 9.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 200);  
                    //resultado => preco = (m³ + gavetas130%) * R$ 200,00
                    break;
                case "Conpensado":  //altura * largura * profundidade em cm 
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 150);  
                    //resultado => preco = (m³ + gavetas130%) * R$ 150,00
                    break;
                default:  //se o material informado nao for valido o material do movel sera MDF
                    this.material = "MDF";
                    peso = (float)(((altura * largura * profundidade)/1000000)* 8.3); //resultado kg
                    preco = (float)((((altura*largura*profundidade)/ 1000000) + (gavetas * 1.3)) * 150);  
                    //resultado => preco = (m³ + gavetas130%) * R$ 150,00
                    break;
            }
        }
    }
}