using System;
using System.Collections.Generic;

namespace Memento
{
    public class Memento
    {
        public String state;
        public Memento(String stateToSave) => state = stateToSave;
    }

    public class Originator
    {
        private String state;
        public void set(String state)
        {
            this.state = state;
            Console.WriteLine("Originator: Setting state to " + state);
        }

        public Memento saveToMemento()
        {
            Console.WriteLine("Originator: Saving to Memento.");
            return new Memento(this.state);
        }

        public void restoreFromMemento(Memento memento)
        {
            this.state = memento.state;
            Console.WriteLine("Originator: State after restoring from Memento: " + state);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Memento> savedStates = new List<Memento>();
            Originator originator = new Originator();
            originator.set("State1");
            originator.set("State2");
            savedStates.Add(originator.saveToMemento());
            originator.set("State3");
            savedStates.Add(originator.saveToMemento());
            originator.set("State4");
            originator.restoreFromMemento(savedStates[1]);
        }
    }
}
