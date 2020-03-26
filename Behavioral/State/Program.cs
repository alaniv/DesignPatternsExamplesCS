using System;

namespace State
{
    public interface EstadoDeAnimo
    {
        void Hablar();
        void GolpeDeLaVida(Humano context);
    }

    public class Feliz : EstadoDeAnimo
    {
        private int resistencia;
        public Feliz()
        {
            this.resistencia = 2;
        }
        public void Hablar()
        {
            Console.WriteLine("Estoy Feliz. Todo marcha bien.");
        }
        public void GolpeDeLaVida(Humano context)
        {
            Console.WriteLine("<Pasan cosas...>");
            if (--this.resistencia == 0)
            {
                context.setEstadoDeAnimo(new Infeliz());
            }
        }
    }

    public class Infeliz : EstadoDeAnimo
    {
        public void Hablar()
        {
            Console.WriteLine("Ya no soy Feliz...");
        }
        public void GolpeDeLaVida(Humano context)
        {
            Console.WriteLine("<Pasan cosas... pero ya no le afectan...>");
        }
    }

    public class Humano
    {
        private EstadoDeAnimo estado; // no necesito get para esto
        public Humano()
        {
            estado = new Feliz();
        }
        public void Hablar()
        {
            estado.Hablar();
        }
        public void Vivir()
        {
            estado.GolpeDeLaVida(this);
        }
        public void setEstadoDeAnimo(EstadoDeAnimo e)
        {
            estado = e;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<State of life>");
            Humano h = new Humano();
            h.Hablar();
            h.Vivir();
            h.Hablar();
            h.Vivir();
            h.Hablar();
            h.Vivir();
            h.Hablar();
        }
    }
}
