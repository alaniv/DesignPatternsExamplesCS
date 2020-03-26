using System;

namespace Adapter
{
    public interface Dog
    {
        void bark();
    }

    public interface Cat
    {
        void meow();
    }

    public class CommonDog : Dog
    {
        public void bark()
        {
            Console.WriteLine("Woof Woof");
        }
    }

    public class CommonCat : Cat
    {
        public void meow()
        {
            Console.WriteLine("meow meow");
        }
    }

    public class DogCostumeForCat : Dog
    { // adapter
        Cat cat;
        public DogCostumeForCat(Cat cat)
        {
            this.cat = cat;
        }
        public void bark()
        {
            cat.meow();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Can a cat bark? - Adapter>");
            Cat c = new CommonCat();
            Dog d = new DogCostumeForCat(c);
            d.bark();
            Console.WriteLine("<A puppy costume was enough!>");
        }
    }
}
