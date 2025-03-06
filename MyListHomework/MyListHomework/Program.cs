using System.Collections.Generic;

namespace MyListHomework
{
    internal class Program
    {
        public static void Print<T>(MyList<T> values)
        {
            foreach (T i in values)
            {
                Console.Write(i+ "; ");
            }
            Console.WriteLine();
            Console.WriteLine("Capacity: " + values.Capacity);
            Console.WriteLine("Count: " + values.Count);
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            Print(list);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            Print(list);
            list.Remove(0);
            list.Remove(9);
            list.Remove(0);
            Print(list);
        }
    }
}
