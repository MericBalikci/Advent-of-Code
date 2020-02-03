using System;

public class Solution_01
{
    public void TakeInput()
    {
        throw new NotImplementedException();
    }

    public void SolvePartOne()
    {
        int result = 0;
        foreach (int position in Fuel_Management_System.Positions)
        {
            result += Fuel_Management_System.CalculateFuelNeeded(position);
        }
        Console.WriteLine(result.ToString());
    }

    public void SolvePartTwo()
    {
        Console.WriteLine(Fuel_Management_System.TotalFuelNeeded(Fuel_Management_System.Positions));
    }
}