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
            int _i = text.LastIndexOf("," + Environment.NewLine);

            string _mass = text.Substring(0, _i + 3);

            string _text = text.Substring(_i+3);
            string[] arr = _text.ToCharArray().Select(c => c.ToString()).ToArray();

            GetPer(arr, _mass);
            Console.WriteLine($"Create {CountWork} work!");
        }
        private static void Swap(ref string a, ref string b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(string[] list, string mass)
        {
            int x = list.Length - 1;
            GetPer(list, mass, 0, x);
        }

        private static void GetPer(string[] list, string mass, int k, int m)
        {
            if (k == m)
            {
                string text = mass;

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
