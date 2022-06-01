using System;
using System.Collections.Generic;

namespace MarcenariaMarcelus
{
    public class Pedido
    {
        public Cliente cliente;
        public List<Movel> moveis;
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
            moveis = new List<Movel>();
        }
        public void calcularValorTotal()
        {
            float fatura = 0;
            foreach (var movel in moveis)
            {
                fatura += movel.preco;
                valor = fatura + valor_frete;
            }
        }
        public void calcularPrazoFabricacao()
        {
            int quantidade = moveis.Count;
            switch (quantidade)
            {
                case 1:
                    foreach (var movel in moveis)
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
                    break;
                case 2:
                    prazo_fabricacao = data_pedido.AddDays(21);
                    break;
                case 3:
                    prazo_fabricacao = data_pedido.AddDays(45);
                    break;
                default:
                    prazo_fabricacao = data_pedido.AddDays(60);
                    break;
            }
            data_entrega = prazo_fabricacao;
        }
        public void calcularValorFrete() //calcula o valor do frete e a data de entrega
        {
            switch (tipo_frete)
            {
                case "A retirar":
                    valor_frete = 0;
                    data_entrega = prazo_fabricacao;
                    break;
                case "Transportadora":
                    float somaPeso = 0;
                    if (endereco_entrega == "Aracatuba")
                    {
                        foreach (var movel in moveis)
                        {
                            somaPeso += movel.peso;
                            valor_frete = somaPeso * 2 + 70;
                        }
                        data_entrega = prazo_fabricacao.AddDays(2);
                    }
                    else
                    {
                        foreach (var movel in moveis)
                        {
                            somaPeso += movel.peso;
                            valor_frete = somaPeso * 2 + 230;
                        }
                        data_entrega = prazo_fabricacao.AddDays(14);
                    }
                    break;
                default: //se o tipo de frete nao for valido o tipo de frete sera por padrao a retirar
                    tipo_frete = "A retirar";
                    data_entrega = prazo_fabricacao;
                    valor_frete = 0;
                    break;
            }
        }
    }
}