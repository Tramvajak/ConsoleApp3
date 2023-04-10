using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class RunWork
    {
        static int _nJob = 0;
        public RunWork(int nJob)
        {
            _nJob = nJob;
            LoadFromFile($"job{nJob}.jb");
        }
        private static void LoadFromFile(string filename)
        {
            string text = null;
            using (StreamReader sr = new StreamReader(filename))
            {
                text = sr.ReadToEnd();
            }
            text = text.Remove(text.Length-2);
            int _i = text.LastIndexOf(Environment.NewLine);

            Console.WriteLine($"Load file {filename}\n");

            int[][] mass = ParseStringToMass(text.Remove(_i));

            string _text = text.Substring(_i + 2);
            Console.WriteLine($"Work: {_text}\n");
            Console.WriteLine($"Table: \n{text.Remove(_i)}");
            string[] arr = _text.ToCharArray().Select(c => c.ToString()).ToArray();

            Work(arr, mass);
        }
        private static int[][] ParseStringToMass(string text)
        {
            int x = 0;


            string[] _t = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int[][] mass = new int[_t.Length][];

            foreach (var item in _t)
            {

                List<int> values = new List<int>();
                string[] _temp = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                mass[x] = new int[_temp.Length];
                for (int i = 0; i < _temp.Length; i++)
                {
                    mass[x][i] = Int32.Parse(_temp[i].ToString());
                }
                x++;
            }

            return mass;

        }
        private static void Work(string[] arr, int[][] mass)
        {
            int A = 0, B = 1, C = 2;

            List<int> road = new List<int>();
            Dictionary<string,int> map = new Dictionary<string, int>();
            map.Add("A", 0);
            map.Add("B", 1);
            map.Add("C", 2);
            map.Add("D", 3);

            foreach (var item in arr)
            {
                int _a = -1;
                if(map.TryGetValue(item, out _a)) 
                {
                    road.Add(_a);
                }
            }
            int summ = 0;
            for (int i = 0; i < road.Count-1; i++)
            {
                int s = mass[road[i]][road[i + 1]];
                summ += s;
            }


            using (StreamWriter sw = new StreamWriter("complite" + _nJob + ".jb"))
            {
                sw.WriteLine(summ);
            }

            Console.WriteLine($"Result: {summ}");
        }
    }
}
