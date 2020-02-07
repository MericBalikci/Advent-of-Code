using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class Solution_01
{
    private static List<int> input;

    private static void TakeInput()
    {
        List<string> rawInput = File.ReadLines(Program.DefaultInputPath + "/Day 01.txt").ToList();
        foreach (string str in rawInput)
        {
            input.Add(int.Parse(str));
        }
    }

    public static void SolvePartOne()
    {
        input = new List<int>();
        TakeInput();
        int result = input.Sum(position => Fuel_Management_System.CalculateFuelNeeded(position));
        Console.WriteLine(result.ToString());
    }

    public static void SolvePartTwo()
    {
        input = new List<int>();
        TakeInput();
        Console.WriteLine(Fuel_Management_System.CalculateTotalFuelNeeded(input));
    }
}