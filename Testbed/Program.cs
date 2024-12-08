using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testbed
{
    internal class Program
    {
        private static int[] TrenaryAdd(int[] originalbits)
        {
            int[] returnbits = new int[originalbits.Length];

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
                Console.WriteLine("1");
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

            returnbits = originalbits;

            return returnbits;
        }
        static void Main(string[] args)
        {
            int[] trenaryInts = { 1, 2, 0, 2, 2, 2 };
            // 1, 2, 1, 0, 0 ,0
            trenaryInts = TrenaryAdd(trenaryInts);
            foreach (int i in trenaryInts)
            {
                Console.Write($"{i}, ");
            }
            Console.ReadKey();
        }
    }
}
