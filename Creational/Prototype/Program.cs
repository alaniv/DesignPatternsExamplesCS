using System;

namespace Prototype
{
    public interface Prototype
    {
        Prototype Clone();
    }
    public class ConcretePrototype1 : Prototype
    {
        public Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Prototype>");
            var p = new ConcretePrototype1();
            var p2 = p.Clone();
        }
    }
}
