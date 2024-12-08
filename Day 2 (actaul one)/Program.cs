using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2__actaul_one_
{
    internal class Program
    {
        static bool isSafe(List<int> OGlist)
        {
            bool isSafe = false;
            for (int j = 0; j <= OGlist.Count(); j++)
            {
                bool iterationSafe = true;
                List<int> list = new List<int>(OGlist);
                if (j != list.Count())
                {
                    list.RemoveAt(j);
                }
                bool isIncreasing = list[0] < list[1];
                if (isIncreasing)
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        if (list[i] >= list[i + 1] || Math.Abs(list[i] - list[i + 1]) > 3)
                        {
                            iterationSafe = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < list.Count - 1; i++)
                    {
                        if (list[i] <= list[i + 1] || Math.Abs(list[i] - list[i + 1]) > 3)
                        {
                            iterationSafe = false;
                        }
                    }
                }
                if (iterationSafe)
                {
                    isSafe = true;
                }
            }
            return isSafe;
        }
        static void Main(string[] args)
        {
            const string fileName = "Input.txt";
            List<List<int>> lines = new List<List<int>>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    List<string> tempStr = sr.ReadLine().Split(' ').ToList();
                    List<int> ints = new List<int>();
                    foreach (string str in tempStr)
                    {
                        ints.Add(int.Parse(str));
                    }
                    lines.Add(ints);
                }
            }
            int numSafe = 0;
            foreach (List<int> list in lines)
            {
                numSafe += isSafe(list) ? 1 : 0;
            }
            Console.WriteLine(numSafe);
            Console.ReadKey();
        }
    }
}
