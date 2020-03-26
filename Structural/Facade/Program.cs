using System;

namespace Facade
{
    class PieceA
    {
        public void create()
        {
            Console.WriteLine("PieceA");
        }
        public void use()
        {
            Console.WriteLine("use A");
        }
    }

    class PieceB
    {
        public void create()
        {
            Console.WriteLine("PieceB");
        }
        public void use()
        {
            Console.WriteLine("use B");
        }
    }

    class PieceC
    {
        public void create()
        {
            Console.WriteLine("PieceC");
        }
        public void use()
        {
            Console.WriteLine("use C");
        }
    }

    public class PiecesFacade
    {
        private readonly PieceA a;
        private readonly PieceB b;
        private readonly PieceC c;

        public PiecesFacade()
        {
            a = new PieceA();
            b = new PieceB();
            c = new PieceC();
        }

        public void create()
        {
            a.create();
            b.create();
            c.create();
        }

        public void doStuff()
        { //complexity hidden in facade
            a.use();
            b.use();
            a.use();
            c.use();
            a.use();
            b.use();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pieces = new PiecesFacade();
            pieces.create();
            pieces.doStuff(); //simplified usage
        }
    }
}
