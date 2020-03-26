using System;

namespace Singleton
{
    public class LastManOnEarth
    { //Singleton
        public String name;
        private static LastManOnEarth singleInstance = null;
        private LastManOnEarth()
        {
            Console.WriteLine("The last man is created");
            name = "Pepe";
        }
        public static LastManOnEarth getInstance()
        {
            if (singleInstance == null)
            {
                singleInstance = new LastManOnEarth();
            }
            return singleInstance;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LastManOnEarth l = LastManOnEarth.getInstance();
            Console.WriteLine(l.name);
            LastManOnEarth l2 = LastManOnEarth.getInstance();
            Console.WriteLine(l2.name);
        }
    }
}
