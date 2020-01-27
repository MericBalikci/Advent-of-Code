using System;
using System.IO;
using System.Linq;
using AdventOfCode_2019;
using AdventOfCode_2019.Day_10;
using System.Collections.Generic;
using Solution = AdventOfCode_2019.Day_10.Solution;

namespace AdventOfCode
{
    /// <summary>
    /// Main class where all the solutions run on.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Default path for the inputs.
        /// </summary>
        public static string DefaultInputPath = "/home/meric/Projects/Rider Projects/Advent of Code/2019/Inputs";
        
        /// <summary>
        /// Main method where all the other methods will be called in. 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Monitoring_Station.CreateAsteroidMap();
            for (int y = 0; y <= Monitoring_Station.AsteroidMap.GetUpperBound(1); y++)
            {
                Console.WriteLine("");
                for (int x = 0; x <= Monitoring_Station.AsteroidMap.GetUpperBound(0); x++)
                {
                    Console.Write(Monitoring_Station.AsteroidMap[y,x]);
                }
            }
        }
    }
}