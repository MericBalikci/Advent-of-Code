using System;
using System.Collections.Generic;

namespace AdventOfCode_2019
{
    /// <summary>
    /// 
    /// </summary>
    public static class Space_Image_Encoder
    {
        /// <summary>
        /// 
        /// </summary>
        public static string input;
        
        /// <summary>
        /// 
        /// </summary>
        public static List<int> SpaceImage = new List<int>();
        
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<int,List<int>> layers = new Dictionary<int, List<int>>();
        
        /// <summary>
        /// 
        /// </summary>
        public static List<int> Encode(string image){
            List<int> numbers = new List<int>();          
            foreach (char number in image)
            {
                numbers.Add(Int32.Parse(number.ToString()));
            }
            return numbers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        public static void DivideSpaceImageToLayers(List<int> image)
        {
            int count = 0;
            int layerNumber = 0;
            foreach (int pixel in image)
            {
                if (count % 150 == 0)
                {
                    count = 0;
                    layerNumber += 1;
                    layers.Add(layerNumber,new List<int>());
                }
                layers[layerNumber].Add(pixel);
                count += 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public static int FindInLayerCountOf(int layer,int number)
        {
            int count = 0;
            foreach (int pixel in layers[layer])
            {
                if (pixel.Equals(number))
                {
                    count += 1;
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageLayers"></param>
        /// <returns></returns>
        public static List<int> MergeLayers(Dictionary<int, List<int>> imageLayers)
        {
            List<int> mergedLayer = new List<int>();
            for (int i = 0; i < 150; i++)
            {
                mergedLayer.Add(2);
                foreach (int layerNumber in imageLayers.Keys)
                {
                    if (imageLayers[layerNumber][i] != 2)
                    {
                        mergedLayer[i] = (imageLayers[layerNumber][i]);
                        break;
                    }
                }
            }
            return mergedLayer;
        }
    }
}