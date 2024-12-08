using System;
using System.Collections.Generic;
using System.IO;

namespace Day_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Input.txt";
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }
            /*List<string> lines = new List<string>();
            lines.Add("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");*/
            int sum = 0;
            string line = "";
            foreach (string l in lines)
            {
                line += l;
            }
            List<string> validMuls = new List<string>();
            bool isDo = true;
            List<bool> isDoIndexes = new List<bool>();
            string tempStr = line;
            for (int i = 0; i < line.Length - 6; i++)
            {
                /*if (line[i] == 'w' && line[i + 1] == 'h' && line[i + 2] == 'a' && line[i + 3] == 't' && line[i + 4] == '(' && line[i + 5] == ')' && line[i + 6] == '[' && line[i + 7] == 'd')
                {
                    tempStr = tempStr.Substring(i);
                }*/
                if (line[i] == 'd')
                {
                    if (line[i + 1] == 'o')
                    {
                        if (line[i + 2] == 'n' && line[i + 3] == (char)39 && line[i + 4] == 't' && line[i + 5] == '(' && line[i + 6] == ')')
                        {
                            isDo = false;
                        }
                        else if (line[i + 2] == '(' && line[i + 3] == ')')
                        {
                            isDo = true;
                        }
                    }
                }
                isDoIndexes.Add(isDo);
            }
            for (int i = 0; i < 6; i++)
            {
                isDoIndexes.Add(isDo);
            }
            string tempLine = line;
            bool isDone = false;
            while (!isDone)
            {
                int mulIndex = -1;
                mulIndex = tempLine.IndexOf("mul(");
                if (mulIndex < 0)
                {
                    isDone = true;
                }
                else
                {
                    int closeBracketIndex = 0;
                    bool found = false;
                    for (int i = mulIndex; i < mulIndex + 12; i++)
                    {
                        if (!found && tempLine[i] == ')')
                        {
                            closeBracketIndex = i;
                            found = true;
                        }
                    }
                    if (closeBracketIndex > 0 && isDoIndexes[mulIndex])
                    {
                        if (tempLine.Substring(mulIndex, closeBracketIndex - mulIndex + 1) == "mul(91,61)")
                        {

                        }
                        validMuls.Add(tempLine.Substring(mulIndex, closeBracketIndex - mulIndex + 1));
                        tempLine = tempLine.Substring(closeBracketIndex);
                        isDoIndexes.RemoveRange(0, closeBracketIndex);
                    }
                    else
                    {
                        tempLine = tempLine.Substring(mulIndex + 3);
                        isDoIndexes.RemoveRange(0, mulIndex + 3);
                    }
                }
            }

            foreach (string s in validMuls)
            {
                Console.WriteLine(s);
                try
                {
                    int num1 = int.Parse(s.Substring(4, s.IndexOf(',') - 4));
                    int num2 = int.Parse(s.Substring(s.IndexOf(',') + 1, s.IndexOf(')') - (s.IndexOf(',') + 1)));
                    sum += num1 * num2;
                    Console.WriteLine($"{num1} * {num2} = {num1 * num2} + prev = {sum}");
                }
                catch { }
            }
            Console.ReadKey();
        }
    }
}
