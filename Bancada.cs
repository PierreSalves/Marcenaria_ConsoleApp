namespace MarcenariaMarcelus
{
    public class Bancada : Movel
    {
        private int portas;
        private int gavetas;

        public void calcularPreco()
        {
            
        }
        ///////////////////////////////////////////////////////
        public void setPortas(int portas)
        {
            this.portas = portas;
        }
        public int getPortas()
        {
            return (portas);
        }
        ///////////////////////////////////////////////////////
        public void setGavetas(int gavetas)
        {
            this.gavetas = gavetas;
        }
        public int getGavetas()
        {
            return (gavetas);
        }
    }
}