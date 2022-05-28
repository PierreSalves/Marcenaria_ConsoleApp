using System;

namespace MarcenariaMarcelus
{
    public class Pedido
    {
        public Cliente cliente;
        public Movel movel;
        private float medidaMovel_m3;
        public string tipo_frete;
        public string endereco_entrega;
        public DateTime data_entrega { get; private set; }
        public DateTime prazo_fabricacao { get;private set; }
        public DateTime data_pedido { get; }
        public float valor_frete { get; private set; }
        public float valor { get; private set; }

        public Pedido()
        {
            data_pedido = DateTime.Now;
        }
        public void calcularValorTotal()
        {
            valor = movel.preco + valor_frete;
        }
        public void calcularPrazoFabricacao()
        {
            medidaMovel_m3 = (movel.altura * movel.largura * movel.profundidade) / 1000000;
            if (medidaMovel_m3 < 4)
            {
                prazo_fabricacao = data_pedido.AddDays(14);
            }
            if (medidaMovel_m3 >= 4 && medidaMovel_m3 <= 6)
            {
                prazo_fabricacao = data_pedido.AddDays(21);
            }
            if (medidaMovel_m3 > 6)
            {
                prazo_fabricacao = data_pedido.AddDays(45);
            }
            
        }
        public void calcularValorFrete()
        {
            switch (tipo_frete)
            {
                case "A retirar":
                    valor_frete = 0;
                    data_entrega = prazo_fabricacao;
                    break;
                case "Transportadora":
                    if (endereco_entrega == "Aracatuba")
                    {
                        valor_frete = movel.peso * 2 + 70;
                        data_entrega = prazo_fabricacao.AddDays(2);
                    }
                    else
                    {
                        valor_frete = movel.peso * 2 + 170;
                        data_entrega = prazo_fabricacao.AddDays(14);
                    }
                    break;
            }
        }
        public Array mostrarFatura()
        {
            float[] valor = new float[1];
            return valor;
        }
    }
}