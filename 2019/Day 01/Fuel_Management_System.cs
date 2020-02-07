using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public static class Fuel_Management_System
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static int CalculateFuelNeeded(int position)
    {
        return (int) Math.Floor(position / 3f) - 2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="positions"></param>
    /// <returns></returns>
    public static int CalculateTotalFuelNeeded(List<int> positions)
    {
        int fuelNeeded = 0;
        foreach (int position in positions)
        {
            int result = CalculateFuelNeeded(position);
            fuelNeeded += result;
            while (result > 0)
            {
                result = CalculateFuelNeeded(result);
                if (result > 0)
                {
                    fuelNeeded += result;
                }
            }
        }
        return fuelNeeded;
    }
}