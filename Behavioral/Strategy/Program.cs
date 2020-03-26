using System;

namespace Strategy
{
    public interface IQuackBehaviour
    {
        public void quack();
    }

    public abstract class Duck
    {
        public IQuackBehaviour quackBehaviour;

        public void performQuack()
        {
            quackBehaviour.quack();
        }
    }

    public class Quack : IQuackBehaviour {
        public void quack(){
            System.Console.WriteLine("Quack");
        }
    }
    public class MuteQuack : IQuackBehaviour {
        public void quack(){
            System.Console.WriteLine("...");
        }
    }
    public class Squeak : IQuackBehaviour {
        public void quack(){
            System.Console.WriteLine("Squeak");
        }
    }

    public class CommonDuck : Duck {
        public CommonDuck(){
            quackBehaviour = new Quack();
        }

        public void printName(){
            System.Console.WriteLine("I'm a common duck!");
        }

        public void setQuackBehaviour(IQuackBehaviour qb){
            quackBehaviour = qb;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Quack - Strategy>");
            CommonDuck d = new CommonDuck();
            d.printName();
            d.performQuack();
            d.setQuackBehaviour(new MuteQuack());
            d.performQuack();
            Console.WriteLine("<Poor duck, he couldn't quack anymore...>");
        }
    }
}
