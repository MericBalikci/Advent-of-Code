using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
        public static string DefaultInputPath { get; } = "C:/Projects/DotNet/Console Applications/Advent of Code/2019/Inputs";

        /// <summary>
        /// Main method where all the other methods will be called in. 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Monitoring_Station.CreateAsteroidMap();
            Monitoring_Station.DebugAsteroidMap();
        }
    }
}