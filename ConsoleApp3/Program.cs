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
            int i = 0;
            string[] allfiles = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string filename in allfiles)
            {
                if (filename.Contains("job") && filename.Contains(".jb")) 
                {
                    new RunWork(++i);
                    Console.WriteLine("=======");
                }
                
            }
            Console.WriteLine("=======");
            new Result();
            Console.ReadKey();
        }
        
    }
}
