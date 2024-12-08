using System;
using System.Collections.Generic;
using System.IO;

namespace Day_6
{
    internal class Program
    {
        static char[,] charArr;
        static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            const string fileName = "Input.txt";
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            int startX = -1;
            int startY = -1;
            charArr = new char[lines.Count, lines[0].Length];
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '^')
                    {
                        startX = i;
                        startY = j;
                    }
                    charArr[i, j] = lines[i][j];
                }
            }
            int count = 0;
            int comparisons = 0;
            float total = lines.Count * lines[0].Length;
            /*List<(int, int)> coords = new List<(int, int)>();
            List<char[,]> valids = new List<char[,]>();*/
            for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine($"{(float)((i * lines[0].Length + j) / total) * 100}%");
                    int X = startX;
                    int Y = startY;
                    char[,] tempCharArr = new char[lines[0].Length, lines.Count];
                    for (int a = 0; a < lines.Count; a++)
                    {
                        for (int b = 0; b < lines[0].Length; b++)
                        {
                            comparisons++;
                            tempCharArr[a, b] = charArr[a, b];
                        }
                    }
                    tempCharArr[i, j] = '#';
                    bool isDone = false;
                    int dir = 3;
                    List<(int, int, int)> XsYsDirs = new List<(int, int, int)>();
                    int currentCount = 0;
                    while (!isDone)
                    {
                        currentCount++;
                        if (currentCount > 10000)
                        {
                            Console.WriteLine("Broken");
                            Console.ReadKey();
                        }
                        comparisons++;
                        if (XsYsDirs.Contains((X, Y, dir)))
                        {
                            /*coords.Add((X, Y));
                            valids.Add(tempCharArr);*/
                            isDone = true;
                            count++;
                        }
                        XsYsDirs.Add((X, Y, dir));
                        tempCharArr[X, Y] = 'X';
                        switch (dir)
                        {
                            case 0:
                                if (Y == 0)
                                {
                                    isDone = true;
                                }
                                else
                                {
                                    Y--;
                                    try
                                    {
                                        if (tempCharArr[X, Y - 1] == '#')
                                        {
                                            dir = 3;
                                        }
                                    }
                                    catch
                                    { }
                                }
                                break;
                            case 1:
                                if (X == lines[0].Length - 1)
                                {
                                    isDone = true;
                                }
                                else
                                {
                                    X++;
                                    try
                                    {
                                        if (tempCharArr[X + 1, Y] == '#')
                                        {
                                            dir = 0;
                                        }
                                    }
                                    catch
                                    { }
                                }
                                break;
                            case 2:
                                if (Y == lines.Count - 1)
                                {
                                    isDone = true;
                                }
                                else
                                {
                                    Y++;
                                    try
                                    {
                                        if (tempCharArr[X, Y + 1] == '#')
                                        {
                                            dir = 1;
                                        }
                                    }
                                    catch
                                    { }
                                }
                                break;
                            case 3:
                                if (X == 0)
                                {
                                    isDone = true;
                                }
                                else
                                {
                                    X--;
                                    try
                                    {
                                        if (tempCharArr[X - 1, Y] == '#')
                                        {
                                            dir = 2;
                                        }
                                    }
                                    catch
                                    { }
                                }
                                break;
                        }
                    }
                }
            }
            /*for (int i = 0; i < lines.Count; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    Console.Write(charArr[i, j]);
                }
                Console.WriteLine();
            }
            for (int x = 0; x < coords.Count(); x++)
            {
                (int, int) coord = coords[x];

                Console.WriteLine(coord);
                for (int i = 0; i < lines.Count; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        Console.Write(valids[x][i, j]);
                    }
                    Console.WriteLine();
                }
            }*/
            Console.WriteLine(count);
            Console.WriteLine(comparisons);
            Console.ReadKey();
        }
    }
}
