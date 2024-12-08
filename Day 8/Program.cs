using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    internal class Program
    {
        static char[,] readInput()
        {
            char[,] charArr;
            List<string> lines = new List<string>();
            const string fileName = "Input.txt";
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
                    charArr[i, j] = lines[i][j];
                }
            }
            return charArr;
        }
        static int SOL1(char[,] charArr)
        {
            List<List<char>> antennas;
            List<List<int>> Xs;
            List<List<int>> Ys;
            (antennas, Xs, Ys) = findAntennas(charArr);
            int count = 0;
            // each type of char
            foreach (List<char> list in antennas)
            {
                int index = antennas.IndexOf(list);
                // each specific char
                for (int i = 0; i < list.Count; i++)
                {
                    int x = Xs[index][i];
                    int y = Ys[index][i];
                    for (int j = 0; j < list.Count(); j++)
                    {
                        int thisX = Xs[index][j];
                        int thisY = Ys[index][j];
                        // creating hashes
                        if (!(x == thisX || y == thisY))
                        {
                            int changeX = x - thisX;
                            int changeY = y - thisY;
                            try
                            {
                                if (charArr[thisX - changeX, thisY - changeY] == '.' || charArr[thisX - changeX, thisY - changeY] == '#')
                                {
                                    charArr[thisX - changeX, thisY - changeY] = '#';
                                    count++;
                                }
                            }
                            catch { }

                            try
                            {
                                if (charArr[x - changeX, y - changeY] == '.' || charArr[x - changeX, y - changeY] == '#')
                                {
                                    charArr[x - changeX, y - changeY] = '#';
                                    count++;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            return count + 1;
        }
        static int SOL2(char[,] charArr)
        {
            List<List<char>> antennas;
            List<List<int>> Xs;
            List<List<int>> Ys;
            (antennas, Xs, Ys) = findAntennas(charArr);
            // each type of char
            foreach (List<char> list in antennas)
            {
                int index = antennas.IndexOf(list);
                // each specific char
                for (int i = 0; i < list.Count; i++)
                {
                    int x = Xs[index][i];
                    int y = Ys[index][i];
                    charArr[x, y] = '#';
                    for (int j = 0; j < list.Count(); j++)
                    {
                        int thisX = Xs[index][j];
                        int thisY = Ys[index][j];
                        // creating hashes
                        if (!(x == thisX || y == thisY))
                        {
                            int changeX = x - thisX;
                            int changeY = y - thisY;
                            bool stop = false;
                            int ScaleFactor = 0;
                            while (!stop)
                            {
                                ScaleFactor++;
                                try
                                {
                                    if (charArr[thisX - ScaleFactor * changeX, thisY - ScaleFactor * changeY] == '.' || charArr[thisX - ScaleFactor * changeX, thisY - ScaleFactor * changeY] == '#')
                                    {
                                        charArr[thisX - ScaleFactor * changeX, thisY - ScaleFactor * changeY] = '#';
                                    }
                                }
                                catch { stop = true; }
                            }
                            stop = false;
                            ScaleFactor = 0;
                            while (!stop)
                            {
                                ScaleFactor++;
                                try
                                {
                                    if (charArr[x - ScaleFactor * changeX, y - ScaleFactor * changeY] == '.' || charArr[x - ScaleFactor * changeX, y - ScaleFactor * changeY] == '#')
                                    {
                                        charArr[x - ScaleFactor * changeX, y - ScaleFactor * changeY] = '#';
                                    }
                                }
                                catch { stop = true; }
                            }
                        }
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < charArr.GetLength(0); i++)
            {
                for (int j = 0; j < charArr.GetLength(1); j++)
                {
                    if (charArr[i, j] == '#')
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static (List<List<char>>, List<List<int>>, List<List<int>>) findAntennas(char[,] charArr)
        {
            List<char> indexes = new List<char>();
            List<List<char>> antennas = new List<List<char>>();
            List<List<int>> Xs = new List<List<int>>();
            List<List<int>> Ys = new List<List<int>>();
            for (int i = 0; i < charArr.GetLength(0); i++)
            {
                for (int j = 0; j < charArr.GetLength(1); j++)
                {
                    if (charArr[i, j] != '.')
                    {
                        int index = indexes.IndexOf(charArr[i, j]);
                        if (index != -1)
                        {
                            antennas[index].Add(charArr[i, j]);
                            Xs[index].Add(i);
                            Ys[index].Add(j);
                        }
                        else
                        {
                            antennas.Add(new List<char> { charArr[i, j] });
                            Xs.Add(new List<int> { i });
                            Ys.Add(new List<int> { j });
                            indexes.Add(charArr[i, j]);
                        }
                    }
                }
            }
            return (antennas, Xs, Ys);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(SOL1(readInput()));
            Console.WriteLine(SOL2(readInput()));
            Console.ReadKey();
        }
    }
}
