using System;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public static class IntCode
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int CalculateOpcode(List<int> IntCodeInput)
    {
        int index = 0;
        while (true)
        {
            if (IntCodeInput[index] == 99)
            {
                return IntCodeInput[0];
            }

            int value1 = IntCodeInput[IntCodeInput[index + 1]];
            int value2 = IntCodeInput[IntCodeInput[index + 2]];
            switch (IntCodeInput[index])
            {
                case 1:
                    IntCodeInput[IntCodeInput[index + 3]] = value1 + value2;
                    index += 4;
                    break;
                case 2:
                    IntCodeInput[IntCodeInput[index + 3]] = value1 * value2;
                    index += 4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}