using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Result
    {
        public Result()
        {
            _Result();
        }

        public static void _Result()
        {
            int result = 0;
            string job = null;
            //получаем данные из всех файлов complite
            string[] allfiles = Directory.GetFiles(Environment.CurrentDirectory);
            foreach (string filename in allfiles)
            {
                if (filename.Contains("complite"))
                {
                    using (StreamReader sr = new StreamReader(filename))
                    {
                        int i = Convert.ToInt32(sr.ReadLine()); 
                        if (result < i ) { result = i; job = filename[filename.Length-4].ToString(); }
                    }
                }

            }
            Console.WriteLine($"Work Result: {result} from number job: {job}");
        }
    }
}
