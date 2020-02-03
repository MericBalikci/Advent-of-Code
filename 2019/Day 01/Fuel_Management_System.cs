using System;
using System.Collections.Generic;

public static class Fuel_Management_System
{
    /// <summary>
    /// 
    /// </summary>
    private static List<int> positions;

    /// <summary>
    /// 
    /// </summary>
    public static List<int> Positions
    {
        get { return positions; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="positionData"></param>
    /// <returns></returns>
    public static int CalculateFuelNeeded(int positionData)
    {
        return (int) Math.Floor(positionData / 3f) - 2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="positionDatas"></param>
    /// <returns></returns>
    public static int TotalFuelNeeded(List<int> positionDatas)
    {
        int totalFuel = 0;
        foreach (int positionData in positionDatas)
        {
            int result = 0;
            result = CalculateFuelNeeded(positionData);
            totalFuel += result;
            while (result > 0)
            {
                result = CalculateFuelNeeded(result);
                if (result > 0)
                {
                    totalFuel += result;
                    Console.WriteLine(result);
                }
            }
        }
        return totalFuel;
    }
}