using System;
using System.Collections.Generic;
using System.Xml;

namespace BubbleSort
{
    class SortProvider
    {
        
        public static int BubbleSort(IList<int> array)
        {
            var counter = 2; //Array get then get accessor = 2 operations
            var length = array.Count;
            for (var i = 0; i < length - 1; i++)
            for (var j = 0; j < length - i - 1; j++)
                if (array[j] > array[j + 1])
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    counter += 4; //Сравнение, и три записи
                }

            return counter;
        }

        public static void InvokeBenchmark(int length)
        {
            var iterationCount = 50;
            var counter = 0;
            for (var q = 0; q < iterationCount; q++)
                counter += BubbleSort(GenerateArray(length));
            Console.WriteLine($"Length {length} - AVG {Math.Floor((decimal) (counter / iterationCount))}");
        }

        private static int[] GenerateArray(int length)
        {
            var resultArray = new int[length];
            var randomNumberProvider = new Random();
            for (var i = 0; i < length; i++)
            {
                resultArray[i] = randomNumberProvider.Next();
            }

            return resultArray;
        }

        public static int[] ParseXML(string path)
        {
            var result = new List<int>();
            var xDoc = new XmlDocument();
            xDoc.Load(path);
            var xRoot = xDoc.DocumentElement;
            foreach (XmlNode node in xRoot)
            {
                result.Add(Int32.Parse(node.Attributes.GetNamedItem("length").Value));
            }
            return result.ToArray();
        }
    }
}