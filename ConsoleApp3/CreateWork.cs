using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class CreateWork
    {
        private static int CountWork = 0;
        public CreateWork()
        {
            LoadFromFile();
        }
        private static void LoadFromFile()
        {
            string text = null;
            using (StreamReader sr = new StreamReader("job.txt"))
            {
                text = sr.ReadToEnd();
            }
            int _i = text.LastIndexOf(Environment.NewLine);
            

            
            int[][] mass = ParseStringToMass(text.Remove(_i));

            string _text = text.Substring(_i+2);
            string[] arr = _text.ToCharArray().Select(c => c.ToString()).ToArray();

            GetPer(arr, mass);
            Console.WriteLine($"Create {CountWork} work!");
        }
        private static int[][] ParseStringToMass(string text)
        {
            int x = 0;
            

            string[] _t = text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

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
        private static string ParseMassToString(int[][] mass)
        {
            string text = null;
            foreach (var item in mass)
            {
                foreach (var _item in item)
                {
                    text = text + _item + ",";
                }
                text = text + Environment.NewLine;
            }
            return text;
        }
        private static void Swap(ref string a, ref string b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(string[] list, int[][] mass)
        {
            int x = list.Length - 1;
            GetPer(list, mass, 0, x);
        }

        private static void GetPer(string[] list, int[][] mass, int k, int m)
        {
            if (k == m)
            {
                string text = ParseMassToString(mass);

                foreach (var item in list)
                {
                    text = text + item;
                }

                text = text + list[0];
                SaveFromFile(String.Format("job{0}.jb", ++CountWork), text);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list,mass, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }
        private static void SaveFromFile(string filename, string text)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(text);
            }
            Console.WriteLine($"Save from {filename}");
        }

    }

    
}
