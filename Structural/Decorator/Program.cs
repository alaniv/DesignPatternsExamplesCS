using System;

namespace Decorator
{
    public abstract class Beverage
    {
        protected String description = "Unknown Beverage";
        public virtual String getDescription()
        {
            return description;
        }
        public abstract double cost();
    }

    public abstract class BeverageCondiment : Beverage
    { //Decorator
        public override abstract String getDescription(); //must reimplement
    }

    public class Expresso : Beverage
    {
        public Expresso()
        {
            description = "Expresso";
        }
        public override double cost()
        {
            return 2.00;
        }
    }

    public class Cocoa : BeverageCondiment
    {
        private Beverage beverage;

        public Cocoa(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String getDescription()
        {
            return beverage.getDescription() + ", with Cocoa";
        }

        public override double cost()
        {
            return 0.50 + beverage.cost();
        }
    }

    public class Milk : BeverageCondiment
    {
        private Beverage beverage;

        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }

        public override String getDescription()
        {
            return beverage.getDescription() + ", with Milk";
        }

        public override double cost()
        {
            return 0.35 + beverage.cost();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Decorating an Expresso>");
            Beverage expresso = new Expresso();
            Console.WriteLine($"What: {expresso.getDescription(),-40} How Much: ${expresso.cost():F2}");
            expresso = new Cocoa(expresso);
            Console.WriteLine($"What: {expresso.getDescription(),-40} How Much: ${expresso.cost():F2}");
            expresso = new Milk(expresso);
            Console.WriteLine($"What: {expresso.getDescription(),-40} How Much: ${expresso.cost():F2}");
            Console.WriteLine("<Tasty!>");
        }
    }
}
