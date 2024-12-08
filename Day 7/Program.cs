using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_7
{
    internal class Program
    {
        static bool isFull(int[] trenary)
        {
            foreach (int i in trenary)
            {
                if(i != 2)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool[] BinaryAdd(bool[] originalbits, long valuetoadd)
        {
            bool[] returnbits = new bool[originalbits.Length];

            for (long i = 0; i <= valuetoadd - 1; i++)
            {
                bool r = false; //r=0
                for (long j = originalbits.Length - 1; j <= originalbits.Length; j--)
                {
                    bool breakcond = false;
                    bool o1 = originalbits[j];
                    if (r == false)
                    {
                        if (o1 == false) { o1 = true; breakcond = true; }//break
                        else if (o1 == true) { o1 = false; r = true; }
                    }
                    else
                    {
                        if (o1 == false) { o1 = true; breakcond = true; }//break
                        else if (o1 == true) { o1 = false; r = true; }
                    }

                    originalbits[j] = o1;
                    if (breakcond == true)
                    {
                        break;
                    }
                }

            }
            returnbits = originalbits;

            return returnbits;
        }
        private static int[] TrenaryAdd(int[] originalbits)
        {
            bool carry = false;
            if (originalbits[originalbits.Length - 1] == 2)
            {
                carry = true;
                originalbits[originalbits.Length - 1] = 0;
            }
            else
            {
                originalbits[originalbits.Length - 1]++;
            }
            for (long i = originalbits.Length - 2; i >= 0; i--)
            {
                if (carry)
                {
                    if (originalbits[i] == 2)
                    {
                        carry = true;
                        originalbits[i] = 0;
                    }
                    else
                    {
                        carry = false;
                        originalbits[i]++;
                    }
                }
            }
            return originalbits;
        }
        static void Main(string[] args)
        {
            List<long> testVals = new List<long>();
            List<List<int>> nums = new List<List<int>>();
            const string fileName = "Input.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    var tempStr = sr.ReadLine();
                    var tempArr = tempStr.Split(':');
                    testVals.Add(long.Parse(tempArr[0]));
                    List<int> tempNums = new List<int>();
                    foreach (var val in tempArr[1].Trim().Split(' '))
                    {
                        tempNums.Add(int.Parse(val.ToString()));
                    }
                    nums.Add(tempNums);
                }
            }
            // 0 will be +, 1 will be *, 2 will be ||
            long count = 0;
            for (int i = 0; i < testVals.Count; i++)
            {
                bool works = false;
                long testVal = testVals[i];
                List<int> theseNums = nums[i];
                int numOps = theseNums.Count - 1;
                int[] trenary = new int[numOps];
                for (int j = 0; j < trenary.Length; j++) trenary[j] = 0;
                if (theseNums.Sum() == testVal) works = true;
                while (!isFull(trenary) && !works)
                {
                    trenary = TrenaryAdd(trenary);
                    long thisSum;
                    if (trenary[0] == 0)
                    {
                        thisSum = theseNums[0] + theseNums[1];
                    }
                    else if (trenary[0] == 1)
                    {
                        thisSum = theseNums[0] * theseNums[1];
                    }
                    else
                    {
                        thisSum = long.Parse(theseNums[0].ToString() + theseNums[1].ToString());
                    }
                    for (int j = 1; j < trenary.Length; j++)
                    {
                        if (trenary[j] == 0)
                        {
                            thisSum += theseNums[j + 1];
                        }
                        else if (trenary[j] == 1)
                        {
                            thisSum *= theseNums[j + 1];
                        }
                        else
                        {
                            thisSum = long.Parse(thisSum.ToString() + theseNums[j + 1].ToString());
                        }
                    }
                    if (thisSum == testVal)
                    {
                        works = true;
                    }
                }
                if (works) count += testVal;
            }
            Console.Write(count);
            Console.ReadKey();
        }
    }
}
