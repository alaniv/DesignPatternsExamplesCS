using System;
using System.Collections.Generic;

namespace Visitor
{
    public interface Visitor
    {
        void Visit(Mouse a);
        void Visit(Cat a);
        void Visit(Dog a);
    }
    public interface VisitableElement
    {
        void AcceptVisit(Visitor v);
    }

    public class Mouse : VisitableElement
    {
        public void AcceptVisit(Visitor v) => v.Visit(this);
    }
    public class Cat : VisitableElement
    {
        public void AcceptVisit(Visitor v) => v.Visit(this);
    }
    public class Dog : VisitableElement
    {
        public void AcceptVisit(Visitor v) => v.Visit(this);
    }

    public class AnimalReviewer : Visitor
    {
        public void Visit(Mouse a)
        {
            Console.WriteLine("This is a nice Mouse!");
        }
        public void Visit(Cat a)
        {
            Console.WriteLine("This is a nice Cat!");
        }
        public void Visit(Dog a)
        {
            Console.WriteLine("This is a nice Dog!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Visitor>");
            AnimalReviewer visitor = new AnimalReviewer();
            List<VisitableElement> l = new List<VisitableElement> { new Mouse(), new Cat(), new Dog() };
            foreach (VisitableElement e in l)
            {
                e.AcceptVisit(visitor);
            }
        }
    }
}
