using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new CreateWork();
            Console.WriteLine();
            new RunWork(1);
            new RunWork(2);
            new RunWork(3);
            new RunWork(4);
            new RunWork(5);
            new RunWork(6);
            Console.WriteLine();
            new Result();
            Console.ReadKey();
        }
        
    }
}
