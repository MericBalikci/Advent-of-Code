using System.Collections.Generic;

namespace AdventOfCode.Utils
{
    public static class String_Utils
    {
        public static List<string> PermutationOfString = new List<string>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        public static void GetPermutationOfString(string str, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                PermutationOfString.Add(str);        
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    str = SwapElementsOfString(str, startIndex, i);
                    GetPermutationOfString(str, startIndex + 1, endIndex);
                    str = SwapElementsOfString(str, startIndex, i);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string SwapElementsOfString(string str, int first, int second)
        {
            char[] charArray = str.ToCharArray();
            char temp = charArray[first];
            charArray[first] = charArray[second];
            charArray[second] = temp;
            string s = new string(charArray);
            return s;
        }
    }
}