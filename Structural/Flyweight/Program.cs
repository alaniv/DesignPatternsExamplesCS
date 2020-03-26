using System;
using System.Collections.Generic;

namespace Flyweight
{

    public interface IArbolLigero //FlyweightBase
    {
        String getTipo();
        void dibujar(long x, long y, long z);
    }
    public class ModeloArbol : IArbolLigero //ConcreteFlyweight
    {
        private String tipo;
        public ModeloArbol(String tipo)
        {
            this.tipo = tipo;
            Console.WriteLine($"nuevo ModeloArbol creado! {tipo}");
        }
        public String getTipo() => this.tipo;
        public void dibujar(long x, long y, long z)
        {
            Console.WriteLine("Árbol [" + this.getTipo() + "] dibujado en las coordenadas (" + x + ", " + y + ", " + z + ")");
        }
    }

    public class FullArbol
    {
        private long x, y, z;
        private IArbolLigero arbol;
        public FullArbol(IArbolLigero arbol, long x, long y, long z)
        {
            this.arbol = arbol;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void dibujarEnMapa()
        {
            arbol.dibujar(x, y, z);
        }
    }

    public class FabricaDeArboles //Flyweight factory
    {
        private Dictionary<String, ModeloArbol> arboles;
        public FabricaDeArboles() => this.arboles = new Dictionary<String, ModeloArbol>();
        public IArbolLigero getArbol(String tipo)
        {
            if (!arboles.ContainsKey(tipo))
                arboles.Add(tipo, new ModeloArbol(tipo));
            return arboles[tipo];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Flyweight>");
            int num_arboles = 10;
            String[] tipos = { "pino", "abeto", "sauce" };
            FabricaDeArboles fabricaDeArboles = new FabricaDeArboles();
            List<FullArbol> fullArboles = new List<FullArbol>();
            Random r = new Random(123456),
            p = new Random(123456);
            for (int i = 0; i < num_arboles; i++)
            {
                fullArboles.Add(
                    new FullArbol(
                        fabricaDeArboles.getArbol(tipos[r.Next() % 3]),
                        p.Next() % 100,
                        p.Next() % 100,
                        p.Next() % 100
                    )
                );
            }
            foreach (FullArbol arbol in fullArboles)
            {
                arbol.dibujarEnMapa();
            }
        }
    }
}
