using System;

namespace Command
{
    public class Light //receiver
    {
        private bool isOn;
        public Light()
        {
            isOn = false;
            Console.WriteLine("new Light OFF");
        }

        public void TurnOn()
        {
            Console.WriteLine("Light ON");
        }
        public void TurnOff()
        {
            Console.WriteLine("Light OFF");
        }
    }
    public interface LightCommand // command
    {
        void Execute();
    }

    public class TurnOnCommand : LightCommand
    {
        private Light light;
        public TurnOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOn();
        }
    }
    public class TurnOffCommand : LightCommand
    {
        private Light light;
        public TurnOffCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.TurnOff();
        }
    }

    public class Switch // invoker
    {
        public LightCommand turnOnCommand;
        public LightCommand turnOffCommand;

        public void TurnLightOn()
        {
            turnOnCommand.Execute();
        }
        public void TurnLightOff()
        {
            turnOffCommand.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<Command - Light switch>");
            Light l = new Light();
            Switch s = new Switch();
            s.turnOnCommand = new TurnOnCommand(l);
            s.turnOffCommand = new TurnOffCommand(l);
            s.TurnLightOn();
            s.TurnLightOff();
            Console.WriteLine("<It's dark in here...>");
        }
    }
}
