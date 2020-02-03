using System;
using System.Collections.Generic;

public class Solution_09
{
    /// <summary>
    /// 
    /// </summary>
    private static void LaunchBOOST()
    {
        List<long> BOOST = new List<long>()
        {
            1102, 34463338, 34463338, 63, 1007, 63, 34463338, 63, 1005, 63, 53, 1102, 1, 3, 1000, 109, 988, 209, 12, 9,
            1000, 209, 6, 209, 3, 203, 0, 1008, 1000, 1, 63, 1005, 63, 65, 1008, 1000, 2, 63, 1005, 63, 904, 1008, 1000,
            0, 63, 1005, 63, 58, 4, 25, 104, 0, 99, 4, 0, 104, 0, 99, 4, 17, 104, 0, 99, 0, 0, 1102, 1, 1, 1021, 1101,
            0, 21, 1009, 1101, 0, 28, 1005, 1102, 1, 27, 1015, 1102, 39, 1, 1016, 1102, 1, 30, 1003, 1102, 25, 1, 1007,
            1102, 195, 1, 1028, 1101, 0, 29, 1010, 1102, 26, 1, 1004, 1102, 1, 555, 1024, 1102, 32, 1, 1014, 1101, 0,
            23, 1019, 1102, 1, 31, 1008, 1101, 652, 0, 1023, 1102, 20, 1, 1000, 1101, 0, 821, 1026, 1102, 814, 1, 1027,
            1102, 1, 36, 1017, 1101, 0, 38, 1006, 1102, 1, 37, 1011, 1102, 33, 1, 1001, 1102, 35, 1, 1013, 1102, 190, 1,
            1029, 1102, 1, 22, 1018, 1101, 0, 0, 1020, 1102, 1, 34, 1012, 1102, 24, 1, 1002, 1101, 0, 655, 1022, 1102,
            1, 546, 1025, 109, 37, 2106, 0, -9, 4, 187, 1106, 0, 199, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -32, 1202,
            1, 1, 63, 1008, 63, 38, 63, 1005, 63, 225, 4, 205, 1001, 64, 1, 64, 1106, 0, 225, 1002, 64, 2, 64, 109, 6,
            1206, 10, 241, 1001, 64, 1, 64, 1106, 0, 243, 4, 231, 1002, 64, 2, 64, 109, -12, 1207, 2, 32, 63, 1005, 63,
            259, 1106, 0, 265, 4, 249, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, 2, 2101, 0, 0, 63, 1008, 63, 33, 63, 1005,
            63, 291, 4, 271, 1001, 64, 1, 64, 1106, 0, 291, 1002, 64, 2, 64, 109, 21, 1205, -1, 305, 4, 297, 1106, 0,
            309, 1001, 64, 1, 64, 1002, 64, 2, 64, 109, -10, 2108, 29, -7, 63, 1005, 63, 329, 1001, 64, 1, 64, 1106, 0,
            331, 4, 315, 1002, 64, 2, 64, 109, -15, 2107, 26, 10, 63, 1005, 63, 347, 1106, 0, 353, 4, 337, 1001, 64, 1,
            64, 1002, 64, 2, 64, 109, 13, 21107, 40, 41, 2, 1005, 1012, 375, 4, 359, 1001, 64, 1, 64, 1106, 0, 375,
            1002, 64, 2, 64, 109, 7, 21107, 41, 40, -5, 1005, 1012, 391, 1105, 1, 397, 4, 381, 1001, 64, 1, 64, 1002,
            64, 2, 64, 109, -6, 21102, 42, 1, 2, 1008, 1013, 40, 63, 1005, 63, 421, 1001, 64, 1, 64, 1105, 1, 423, 4,
            403, 1002, 64, 2, 64, 109, -10, 2107, 23, 1, 63, 1005, 63, 441, 4, 429, 1105, 1, 445, 1001, 64, 1, 64, 1002,
            64, 2, 64, 109, 3, 1201, 5, 0, 63, 1008, 63, 21, 63, 1005, 63, 467, 4, 451, 1106, 0, 471, 1001, 64, 1, 64,
            1002, 64, 2, 64, 109, 18, 21108, 43, 43, -5, 1005, 1017, 489, 4, 477, 1105, 1, 493, 1001, 64, 1, 64, 1002,
            64, 2, 64, 109, -29, 1207, 7, 21, 63, 1005, 63, 511, 4, 499, 1106, 0, 515, 1001, 64, 1, 64, 1002, 64, 2, 64,
            109, 23, 21108, 44, 46, -6, 1005, 1010, 531, 1106, 0, 537, 4, 521, 1001, 64, 1, 64, 1002, 64, 2, 64, 109,
            11, 2105, 1, -3, 4, 543, 1001, 64, 1, 64, 1106, 0, 555, 1002, 64, 2, 64, 109, -3, 1205, -4, 571, 1001, 64,
            1, 64, 1105, 1, 573, 4, 561, 1002, 64, 2, 64, 109, -7, 2108, 21, -8, 63, 1005, 63, 595, 4, 579, 1001, 64, 1,
            64, 1105, 1, 595, 1002, 64, 2, 64, 109, -1, 1208, -8, 28, 63, 1005, 63, 615, 1001, 64, 1, 64, 1106, 0, 617,
            4, 601, 1002, 64, 2, 64, 109, -12, 1202, 4, 1, 63, 1008, 63, 29, 63, 1005, 63, 641, 1001, 64, 1, 64, 1106,
            0, 643, 4, 623, 1002, 64, 2, 64, 109, 18, 2105, 1, 1, 1105, 1, 661, 4, 649, 1001, 64, 1, 64, 1002, 64, 2,
            64, 109, -6, 2102, 1, -8, 63, 1008, 63, 31, 63, 1005, 63, 687, 4, 667, 1001, 64, 1, 64, 1106, 0, 687, 1002,
            64, 2, 64, 109, -7, 21102, 45, 1, 6, 1008, 1015, 45, 63, 1005, 63, 709, 4, 693, 1106, 0, 713, 1001, 64, 1,
            64, 1002, 64, 2, 64, 109, -6, 2101, 0, 0, 63, 1008, 63, 31, 63, 1005, 63, 737, 1001, 64, 1, 64, 1105, 1,
            739, 4, 719, 1002, 64, 2, 64, 109, 7, 1208, -8, 24, 63, 1005, 63, 761, 4, 745, 1001, 64, 1, 64, 1105, 1,
            761, 1002, 64, 2, 64, 109, -12, 2102, 1, 10, 63, 1008, 63, 32, 63, 1005, 63, 781, 1106, 0, 787, 4, 767,
            1001, 64, 1, 64, 1002, 64, 2, 64, 109, 16, 1206, 6, 801, 4, 793, 1106, 0, 805, 1001, 64, 1, 64, 1002, 64, 2,
            64, 109, 14, 2106, 0, -1, 1001, 64, 1, 64, 1106, 0, 823, 4, 811, 1002, 64, 2, 64, 109, -18, 1201, -7, 0, 63,
            1008, 63, 27, 63, 1005, 63, 847, 1001, 64, 1, 64, 1105, 1, 849, 4, 829, 1002, 64, 2, 64, 109, -8, 21101, 46,
            0, 10, 1008, 1012, 46, 63, 1005, 63, 875, 4, 855, 1001, 64, 1, 64, 1106, 0, 875, 1002, 64, 2, 64, 109, 13,
            21101, 47, 0, -3, 1008, 1012, 44, 63, 1005, 63, 899, 1001, 64, 1, 64, 1105, 1, 901, 4, 881, 4, 64, 99,
            21101, 27, 0, 1, 21102, 1, 915, 0, 1105, 1, 922, 21201, 1, 11564, 1, 204, 1, 99, 109, 3, 1207, -2, 3, 63,
            1005, 63, 964, 21201, -2, -1, 1, 21101, 942, 0, 0, 1105, 1, 922, 22101, 0, 1, -1, 21201, -2, -3, 1, 21101,
            0, 957, 0, 1106, 0, 922, 22201, 1, -1, -2, 1105, 1, 968, 21202, -2, 1, -2, 109, -3, 2105, 1, 0
        };
        IntCode_V2.CurrentProgram = new List<long>(10000);
        IntCode_V2.CurrentProgram.AddRange(BOOST);
        for (int i = 0; i < 10000 - BOOST.Count; i++)
        {
            IntCode_V2.CurrentProgram.Add(0);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SolvePartOne()
    {
        LaunchBOOST();
        IntCode_V2.SystemId.Enqueue(1);
        Console.WriteLine(IntCode_V2.Run(IntCode_V2.CurrentProgram));
    }

    /// <summary>
    /// 
    /// </summary>
    public static void SolvePartTwo()
    {
        LaunchBOOST();
        IntCode_V2.SystemId.Enqueue(2);
        Console.WriteLine(IntCode_V2.Run(IntCode_V2.CurrentProgram));
    }

    public static void TakeInput()
    {
        throw new NotImplementedException();
    }
}