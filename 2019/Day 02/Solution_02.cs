using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Solution_02
{
    private static List<int> input = new List<int>();

    private static void TakeInput()
    {
       List<string> rawInput = File.ReadAllText(Program.DefaultInputPath+"/Day 02.txt").Split(",").ToList();
       foreach (string str in rawInput)
       {
           input.Add(Int32.Parse(str));
       }
    }

    public static void SolvePartOne()
    {
        TakeInput();
        input[1] = 12;
        input[2] = 2;
        Console.WriteLine(IntCode.CalculateOpcode(input));
    }

    public static void SolvePartTwo()
    {
        for (int a = 0; a < 99; a++)
        {
            for (int b = 0; b < 99; b++)
            {
                input = new List<int>();
                TakeInput();
                input[1] = a;
                input[2] = b;
                if (IntCode.CalculateOpcode(input) != 19690720) continue;
                Console.WriteLine("a: " + a + " b: " +b);
                Console.WriteLine((100*a)+b);
                return;
            }
        }
    }
}