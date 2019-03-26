using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1_cs
{
    class Program
    {
        public static double ShannonEntropy(string s)
        {
            s = File.ReadAllText("D:\\labs_sys_prog\\lab1_cs\\text5.txt", Encoding.GetEncoding(1251));
            var map = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (!map.ContainsKey(c))
                    map.Add(c, 1);
                else
                    map[c] += 1;
            }

            double result = 0.0;
            int len = s.Length;
            foreach (var item in map)
            {
                var frequency = (double)item.Value / len;
                result -= frequency * (Math.Log(frequency) / Math.Log(2));
            }

            return result;
        }
        static void Main(string[] args)
        {
            // 1.
            // Array to store frequencies.
            int[] c = new int[char.MaxValue];

            // 2.
            // Read entire text file.
            string s = File.ReadAllText("D:\\labs_sys_prog\\lab1_cs\\text5.txt", Encoding.GetEncoding(1251));

            // 3.
            // Iterate over each character.
            foreach (char t in s)
            {
                // Increment table.
                c[t]++;
            }

            // 4.
            // Write all letters found.

            for (int i = 0; i < char.MaxValue; i++)
            {
                if (c[i] > 0 && char.IsLetterOrDigit((char)i))
                {
                    Console.WriteLine("Letter: {0}  Frequency: {1}", (char)i, c[i]);
                    //Console.WriteLine(s);
                }
            }
            long length = new System.IO.FileInfo("D:\\labs_sys_prog\\lab1_cs\\text5.txt").Length;
            Console.WriteLine("Entropy: {0}", ShannonEntropy(s));
            Console.WriteLine("Number of signs: {0}", s.Length);
            Console.WriteLine("Amount of info: {0}", (s.Length * ShannonEntropy(s)) / 8);
            Console.WriteLine("File Size: {0}", length);

        }
    }
}
