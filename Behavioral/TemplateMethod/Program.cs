using System;

namespace TemplateMethod
{
    public abstract class Juego
    {
        protected abstract void IniciarJuego();
        protected abstract void HacerJugadas();
        protected void TerminarJuego()
        {
            Console.WriteLine("Terminar Juego.");
        }
        public void Jugar()
        {
            IniciarJuego();
            HacerJugadas();
            TerminarJuego();
        }
    }

    public class Tetris : Juego
    {
        protected override void IniciarJuego()
        {
            Console.WriteLine("Iniciar Tetris");
        }
        protected override void HacerJugadas()
        {
            Console.WriteLine("Moviendo piezas...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Template Method>");
            Juego j = new Tetris();
            j.Jugar();
        }
    }
}
