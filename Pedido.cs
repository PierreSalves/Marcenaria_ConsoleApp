using System;
using System.Collections;

namespace MarcenariaMarcelus
{
    public class Pedido
    {
        Cliente cliente;
        ArrayList Movel; 
        string tipo_frete;
        float valor_frete;
        string endereco_entrega;
        DateTime data_pedido = DateTime.Now;
        DateTime data_entrega;
        float valor;

        public void calcularValorTotal()
        {
            
        }

        public void calcularValorFrete()
        {
            
        }

        public Array mostrarFatura()
        {
            float[] valor = new float[1];
            return valor;
        }
    }
}