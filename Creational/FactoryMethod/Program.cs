using System;

namespace FactoryMethod
{
    public interface Pizza
    {
        void ComerPizza();
    }

    public class PizzaMuzzarella : Pizza
    {
        public void ComerPizza()
        {
            Console.WriteLine("Devorando esta muzza... Listo!");
        }
    }

    public interface FabricaDePizzas
    {
        Pizza CocinarPizza();
    }

    public class FabricaDePizzasMuzzarella : FabricaDePizzas
    {
        public Pizza CocinarPizza()
        {
            return new PizzaMuzzarella();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Pizza baratas - FactoryMethod>");
            FabricaDePizzas uggys = new FabricaDePizzasMuzzarella();
            Pizza p = uggys.CocinarPizza();
            p.ComerPizza();
        }
    }
}
