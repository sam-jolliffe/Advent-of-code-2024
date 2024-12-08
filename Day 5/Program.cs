using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Day_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "Input.txt";
            List<int> firstRules = new List<int>();
            List<int> secondRules = new List<int>();
            List<string> updates = new List<string>();
            bool isRules = true;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string tempStr = sr.ReadLine();
                    if (tempStr.Length < 2)
                    {
                        isRules = false;
                    }
                    else if (isRules)
                    {
                        string[] tempArr = tempStr.Split('|');
                        firstRules.Add(int.Parse(tempArr[0]));
                        secondRules.Add(int.Parse(tempArr[1]));
                    }
                    else
                    {
                        updates.Add(tempStr);
                    }
                }
            }
            List<List<int>> intUpdates = new List<List<int>>();
            foreach (string tempStr in updates)
            {
                string[] tempArr = tempStr.Split(',');
                List<int> tempList = new List<int>();
                foreach (string tempStr2 in tempArr)
                {
                    tempList.Add(int.Parse(tempStr2));
                }
                intUpdates.Add(tempList);
            }
            int outputVal = 0;
            List<List<int>> falseUpdates = new List<List<int>>();
            foreach (List<int> update in intUpdates)
            {
                bool isValid = true;
                for (int i = 0; i < firstRules.Count; i++)
                {
                    if (update.Contains(firstRules[i]) && update.Contains(secondRules[i]))
                    {
                        if (update.IndexOf(firstRules[i]) > update.IndexOf(secondRules[i]))
                        {
                            isValid = false;
                            /*foreach (int i2 in update) { Console.Write($"{i2},"); }
                            Console.WriteLine($": {firstRules[i]}, {secondRules[i]}");*/
                        }
                    }
                }
                if (isValid)
                {
                    // outputVal += update[(update.Count() - 1) / 2];
                }
                else
                {
                    falseUpdates.Add(update);
                }
            }
            List<List<int>> newValidUpdates = new List<List<int>>();
            foreach (List<int> update in falseUpdates)
            {
                bool isOrdered = false;
                List<int> tempUpdate = update;
                while (!isOrdered)
                {
                    bool iterationTrue = true;
                    for (int i = 0; i < firstRules.Count;i++)
                    {
                        if (tempUpdate.Contains(firstRules[i]) && tempUpdate.Contains(secondRules[i]))
                        {
                            if (tempUpdate.IndexOf(firstRules[i]) > tempUpdate.IndexOf(secondRules[i]))
                            {
                                iterationTrue = false;
                                // swaps values
                                int temp = tempUpdate[tempUpdate.IndexOf(firstRules[i])];
                                tempUpdate[tempUpdate.IndexOf(firstRules[i])] = tempUpdate[tempUpdate.IndexOf(secondRules[i])];
                                tempUpdate[tempUpdate.IndexOf(secondRules[i])] = temp;
                            }
                        }
                    }
                    if (iterationTrue)
                    {
                        isOrdered = true;
                    }
                }
                newValidUpdates.Add(tempUpdate);
            }
            foreach (List<int> update in newValidUpdates)
            {
                outputVal += update[(update.Count() - 1) / 2];
            }


            Console.WriteLine(outputVal);
            Console.ReadKey();
            /*if (update[i] == firstRules[j] && update.Contains(secondRules[j]))
                    {
                        if (update.IndexOf(firstRules[j]) < update.IndexOf(secondRules[j]))
                        {
                            isDone = true;
                            outputVal += update[(update.Count() - 1) / 2];
                            foreach (int i2 in update) { Console.Write($"{i2}, "); }
                            Console.WriteLine($": {firstRules[j]}, {secondRules[j]}");
                        }
                    }*/
            
        }
    }
}
