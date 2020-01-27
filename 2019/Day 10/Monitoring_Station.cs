using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode_2019.Day_10
{
    /// <summary>
    /// 
    /// </summary>
    public static class Monitoring_Station
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<double,List<Asteroid>> AsteroidCountsAtLineOfSight = new Dictionary<double, List<Asteroid>>();
        
        /// <summary>
        /// 
        /// </summary>
        public static bool[,] AsteroidMap;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int FindAsteroidCountAtLineOfSight(Asteroid source)
        {
            int count = 0;
            // TO-DO: Check x and y in the for loop order is correct.
            for (int x = source.x; x <= AsteroidMap.GetUpperBound(1); x++)
            {
                for (int y = source.y; y <= AsteroidMap.GetUpperBound(0); y++)
                {
                    if (AsteroidMap[y, x])
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsAsteroidInLineOfSightFrom(Asteroid source, Asteroid target)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static double FindDegreeBetween(Asteroid source, Asteroid target)
        {
            return Math.Atan2((target.y - source.y), (target.x - source.x));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static double FindDistanceToAsteroidFrom(Asteroid source, Asteroid target)
        {
            return Math.Pow((target.y - source.y), 2) + Math.Pow((target.x - source.x), 2);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void CreateAsteroidMap()
        {
            int lineNumber = 0;
            List<string> lines = File.ReadAllLines(Program.DefaultInputPath + "/Day10.txt").ToList(); 
            AsteroidMap = new bool[lines.Count,lines[0].Length];
            foreach (string line in lines)
            {
                int dataIndex = 0;
                foreach (char data in line)
                {
                    if (data.Equals(Char.Parse(".")))
                    {
                        AsteroidMap[lineNumber,dataIndex] = false;
                    }
                    else if(data.Equals(Char.Parse("#")))
                    {
                        AsteroidMap[lineNumber,dataIndex] = true;
                    }
                    else
                    {
                        Console.WriteLine("Asteroid type could not found");
                        throw new ArgumentOutOfRangeException(data.ToString(),data,"Asteroid type could not found");
                    }
                    dataIndex += 1;
                }
                lineNumber += 1;
            }
        }
    }
}