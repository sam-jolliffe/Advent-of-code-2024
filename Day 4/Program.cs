using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4
{
    internal class Program
    {
        
        static char[,] charArr;
        static void Main(string[] args)
        {
            int numOccourances = 0;
            const string fileName = "Input.txt";
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            charArr = new char[lines.Count, lines[0].Length];
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    charArr[i,j] = lines[i][j];
                }
            }
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    int numDiagonals = 0;
                    if (charArr[i,j] == 'A')
                    {
                        if (i >= 1 && j < charArr.GetLength(1) - 1 && j >= 1 && i < charArr.GetLength(0) - 1)
                        {
                            // top left diagonal
                            if ((charArr[i - 1, j - 1] == 'M' && charArr[i + 1, j + 1] == 'S') || (charArr[i - 1, j - 1] == 'S' && charArr[i + 1, j + 1] == 'M'))
                            {
                                numDiagonals++;
                            }
                            // top right diagonal
                            if ((charArr[i - 1, j + 1] == 'M' && charArr[i + 1, j - 1] == 'S') || (charArr[i - 1, j + 1] == 'S' && charArr[i + 1, j - 1] == 'M'))
                            {
                                numDiagonals++;
                            }
                        }
                        if (numDiagonals >= 2 ) { numOccourances++; }
                        
                    }
                    /*if (charArr[i,j] == 'X')
                    {
                        // up
                        if (i >= 3 && charArr[i - 1, j] == 'M' && charArr[i - 2, j] == 'A' && charArr[i - 3, j] == 'S')
                        {
                            numOccourances++;
                        }
                        // down
                        if (i < charArr.GetLength(0) - 3 && charArr[i + 1, j] == 'M' && charArr[i + 2, j] == 'A' && charArr[i + 3, j] == 'S')
                        {
                            numOccourances++;
                        }
                        // left
                        if (j >= 3 && charArr[i, j - 1] == 'M' && charArr[i, j - 2] == 'A' && charArr[i, j - 3] == 'S')
                        {
                            numOccourances++;
                        }
                        // right
                        if (j < charArr.GetLength(1) - 3 && charArr[i, j + 1] == 'M' && charArr[i, j + 2] == 'A' && charArr[i, j + 3] == 'S')
                        {
                            numOccourances++;
                        }
                        // up left
                        if (i >= 3 && j >= 3 && charArr[i - 1, j - 1] == 'M' && charArr[i - 2, j - 2] == 'A' && charArr[i - 3, j - 3] == 'S')
                        {
                            numOccourances++;
                        }
                        // up right
                        if (i >= 3 && j < charArr.GetLength(1) - 3 && charArr[i - 1, j + 1] == 'M' && charArr[i - 2, j + 2] == 'A' && charArr[i - 3, j + 3] == 'S')
                        {
                            numOccourances++;
                        }
                        // down left
                        if (j >= 3 && i < charArr.GetLength(0) - 3 && charArr[i + 1, j - 1] == 'M' && charArr[i + 2, j - 2] == 'A' && charArr[i + 3, j - 3] == 'S')
                        {
                            numOccourances++;
                        }
                        // down right
                        if (j < charArr.GetLength(1) - 3 && i < charArr.GetLength(0) - 3 && charArr[i + 1, j + 1] == 'M' && charArr[i + 2, j + 2] == 'A' && charArr[i + 3, j + 3] == 'S')
                        {
                            numOccourances++;
                        }
                    }*/
                }
            }
            Console.WriteLine(numOccourances.ToString());
            Console.ReadKey();
            /*for(int i = 0; i < charArr.GetLength(0); i++)
            {
                for (int j = 0; j < charArr.GetLength(1); j++)
                {
                    Console.Write(charArr[i, j]);
                }
                Console.Write("\n");
            }
            Console.ReadKey();*/
        }
    }
}
