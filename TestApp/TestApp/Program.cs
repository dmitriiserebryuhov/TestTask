using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClosedList<int> l = new ClosedList<int>() { 1, 2, 3, 4, 5};

            Console.WriteLine("Голова: " + l.Head);
            Console.WriteLine("Текущий: " + l.Current);
            Console.WriteLine("Следующий: " + l.Next);
            Console.WriteLine("Предыдущий: " + l.Previous);
            
            Console.ReadLine();

            l.MoveNext(1);
            l.MoveBack(2);
            

            Console.WriteLine("Голова: " + l.Head);
            Console.WriteLine("Текущий: " + l.Current);
            Console.WriteLine("Следующий: " + l.Next);
            Console.WriteLine("Предыдущий: " + l.Previous);

            Console.ReadLine();
        }
    }
}
