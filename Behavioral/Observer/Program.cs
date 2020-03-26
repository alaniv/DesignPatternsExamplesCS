using System;
using System.Collections;
using System.Collections.Generic;

namespace Observer
{
    public interface ICustomObserver
    {
        public void ReceiveNotification(int num);
    }

    public interface ICustomObservable
    {
        public void Suscribe(ICustomObserver o);
        public void Notify();
        public void Unsuscribe(ICustomObserver o);
    }

    public class WeatherData : ICustomObservable
    {
        private IList observers;
        public WeatherData()
        {
            observers = new List<ICustomObserver>();
        }
        public void Suscribe(ICustomObserver o)
        {
            observers.Add(o);
        }
        public void Notify()
        {
            foreach (ICustomObserver o in observers)
            {
                o.ReceiveNotification(observers.Count);
            }
        }
        public void Unsuscribe(ICustomObserver o)
        {
            observers.Remove(o);
        }
    }

    public class WeatherObserver : ICustomObserver
    {
        public String name;
        public WeatherObserver(String name)
        {
            this.name = name;
        }
        public void ReceiveNotification(int num)
        {
            System.Console.WriteLine($"I'm {name}. There are {num} suscriber to weathervision");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ICustomObserver a = new WeatherObserver("a");
            ICustomObserver b = new WeatherObserver("b");
            ICustomObservable d = new WeatherData();
            Console.WriteLine("<Let's suscribe a>");
            d.Suscribe(a);
            d.Notify();
            Console.WriteLine("<Let's suscribe b>");
            d.Suscribe(b);
            d.Notify();
            Console.WriteLine("<Let's unsuscribe a>");
            d.Unsuscribe(a);
            d.Notify();
        }
    }
}
