using System;

namespace ChainOfResponsability
{
    interface Chain
    {
        void SetNext(Chain nextInChain);
        void Execute(int request);
    }
    class NegativeTest : Chain
    {
        private Chain nextInChain;
        public void SetNext(Chain nextInChain)
        {
            this.nextInChain = nextInChain;
        }
        public void Execute(int request)
        {
            if (request < 0)
                Console.WriteLine("It's negative");
            else
                nextInChain.Execute(request);
        }
    }
    class ZeroTest : Chain
    {
        private Chain nextInChain;
        public void SetNext(Chain nextInChain)
        {
            this.nextInChain = nextInChain;
        }
        public void Execute(int request)
        {
            if (request == 0)
                Console.WriteLine("It's zero");
            else
                nextInChain.Execute(request);
        }
    }
    class PassedTest : Chain
    {
        private Chain nextInChain;
        public void SetNext(Chain nextInChain)
        {
            this.nextInChain = nextInChain;
        }
        public void Execute(int request)
        {
            Console.WriteLine("It's positive!!!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Chain of responsability>");
            Chain neg = new NegativeTest();
            Chain zero = new ZeroTest();
            Chain pos = new PassedTest();
            neg.SetNext(zero);
            zero.SetNext(pos);

            neg.Execute(-10);
            neg.Execute(0);
            neg.Execute(10);
        }
    }
}
