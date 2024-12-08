using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1
{
    internal class Program
    {
        static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }
        static int findDiff()
        {
            int diff = 0;
            const string fileName = "Input.txt";
            List<int> list1 = new List<int>();
            List<int> list2= new List<int>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    list1.Add(int.Parse(tempStr.Substring(0, 5)));
                    list2.Add(int.Parse(tempStr.Substring(8, 5)));
                }
            }
            list1 = SortArray(list1.ToArray(), 0, list1.Count()-1).ToList();
            list2 = SortArray(list2.ToArray(), 0, list2.Count()-1).ToList();   
            for (int i = 0; i < list1.Count; i++)
            {
                diff += Math.Abs(list1[i] - list2[i]);
            }
            return diff;
        }
        static long getSimilarityScore()
        {
            const string fileName = "Input.txt";
            List<long> list1 = new List<long>();
            List<long> list2 = new List<long>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    list1.Add(int.Parse(tempStr.Substring(0, 5)));
                    list2.Add(int.Parse(tempStr.Substring(8, 5)));
                }
            }
            long simScore = 0;
            foreach (int i in list1)
            {
                int count = 0;
                foreach (int j in list2)
                {
                    if (i == j)
                    {
                        count++;
                    }
                }
                simScore += count * i;
            }
            return simScore;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Diff: {getSimilarityScore()}");
            Console.ReadKey();
        }
    }
}
