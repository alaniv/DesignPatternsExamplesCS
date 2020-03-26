using System;

namespace Bridge
{
    public abstract class ElaboradorDeAlimento //Abstraction
    {
        public IProcesador procesador;
        public abstract void elaborar();
    }

    public class ElaboradorDeLasagna : ElaboradorDeAlimento //"Refined abstraction" 1
    {
        public ElaboradorDeLasagna(IProcesador procesador) => this.procesador = procesador;
        public override void elaborar()
        {
            Console.WriteLine("...Elaborando lasagna...");
            this.procesador.procesar();
            Console.WriteLine("Lasagna lista!");
        }
    }

    public class ElaboradorDeEmpanada : ElaboradorDeAlimento //"Refined abstraction" 2
    {
        public ElaboradorDeEmpanada(IProcesador procesador) => this.procesador = procesador;
        public override void elaborar()
        {
            Console.WriteLine("...Elaborando empanada...");
            this.procesador.procesar();
            Console.WriteLine("Empanada lista!");
        }
    }

    public interface IProcesador //Implementation Base
    {
        void procesar();
    }

    public class ProcesadorCarne : IProcesador //Conrete Implementation 1
    {
        public ProcesadorCarne() { }
        public void procesar() => Console.WriteLine("...Procesando Carne...");
    }
    public class ProcesadorVerdura : IProcesador //Conrete Implementation 2
    {
        public ProcesadorVerdura() { }
        public void procesar() => Console.WriteLine("...Procesando Verdura...");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Pastas - Bridge>");
            IProcesador pc = new ProcesadorCarne();
            IProcesador pv = new ProcesadorVerdura();
            ElaboradorDeAlimento elaboradorDeAlimento = new ElaboradorDeLasagna(pc);
            elaboradorDeAlimento.elaborar();
            elaboradorDeAlimento.procesador = pv;
            elaboradorDeAlimento.elaborar();
            elaboradorDeAlimento = new ElaboradorDeEmpanada(pc);
            elaboradorDeAlimento.elaborar();
            elaboradorDeAlimento.procesador = pv;
            elaboradorDeAlimento.elaborar();
        }
    }
}
