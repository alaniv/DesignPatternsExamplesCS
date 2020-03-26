using System;

namespace Proxy
{
    public interface IInternet
    {
        void Connect(String site);
    }

    public class Internet : IInternet
    {
        public void Connect(String site)
        {
            Console.WriteLine("Connected to " + site);
        }
    }

    public class InternetProxy : IInternet
    {
        private Internet internet;
        public InternetProxy()
        {
            internet = new Internet();
        }
        public void Connect(String site)
        {
            Console.WriteLine("Proxy connection");
            if (site == "pepe.com")
            {
                Console.WriteLine("Blocked site: " + site);
                return;
            }
            internet.Connect(site);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Blocked site - Proxy>");
            Console.WriteLine(">Connect without proxy");
            IInternet i = new Internet();
            i.Connect("fido.com");
            i.Connect("pepe.com");
            Console.WriteLine(">Connect with proxy");
            IInternet p = new InternetProxy();
            p.Connect("fido.com");
            p.Connect("pepe.com");
        }
    }
}
