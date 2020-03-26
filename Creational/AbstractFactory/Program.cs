using System;

namespace AbstractFactory
{
    public interface ProductoA { }

    public interface ProductoB { }

    public interface FabricaAbstracta
    {
        ProductoA FabricarProductoA();
        ProductoB FabricarProductoB();
    }

    public class ProductoABajaCalidad : ProductoA { }
    public class ProductoAAltaCalidad : ProductoA { }

    public class ProductoBBajaCalidad : ProductoB { }
    public class ProductoBAltaCalidad : ProductoB { }

    public class FabricaBajaCalidad : FabricaAbstracta
    {
        public ProductoA FabricarProductoA()
        {
            Console.WriteLine("A de baja calidad");
            return new ProductoABajaCalidad();
        }
        public ProductoB FabricarProductoB()
        {
            Console.WriteLine("B de baja calidad");
            return new ProductoBBajaCalidad();
        }
    }

    public class FabricaAltaCalidad : FabricaAbstracta
    {
        public ProductoA FabricarProductoA()
        {
            Console.WriteLine("A de alta calidad");
            return new ProductoAAltaCalidad();
        }
        public ProductoB FabricarProductoB()
        {
            Console.WriteLine("B de alta calidad");
            return new ProductoBAltaCalidad();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Abstract Factory>");
            FabricaAbstracta fa = new FabricaAltaCalidad();
            fa.FabricarProductoA();
            fa.FabricarProductoB();
            FabricaAbstracta fb = new FabricaBajaCalidad();
            fb.FabricarProductoA();
            fb.FabricarProductoB();
        }
    }
}
