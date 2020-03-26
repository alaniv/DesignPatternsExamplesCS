using System;

namespace Iterator
{
    public class Weeks
    {
        private string[] weeks = new string[]{
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
            };

        public IWeeksIterator GetWeeksIterator()
        {
            return new WeeksIterator(weeks);
        }
    }

    public interface IWeeksIterator
    {
        string Current { get; }
        bool Next();
    }

    public class WeeksIterator : IWeeksIterator
    {
        private readonly string[] weeks;
        private int position;

        public WeeksIterator(string[] weeks)
        {
            this.weeks = weeks;
            this.position = 0;
        }

        public string Current
        {
            get
            {
                return weeks[position];
            }
        }
        public bool Next()
        {
            if (position < weeks.Length - 1)
            {
                position++;
                return true;

            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Weeks weeks = new Weeks();
            IWeeksIterator iterator = weeks.GetWeeksIterator();
            do
            {
                Console.WriteLine(iterator.Current);
            } while (iterator.Next());
        }
    }
}
