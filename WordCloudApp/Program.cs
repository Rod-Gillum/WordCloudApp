using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCloudApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            Sorter sorter = new Sorter();
            string filePath = "../../../WordCloudAppTests/Summary.txt";
            Dictionary<string, int> dictionary = parser.ParseFile(filePath).ToDictionary(t => t.Key, t => t.Value);
            Dictionary<string, int> wordsUsedTwice = sorter.ThresholdResults(dictionary, 2, 2).ToDictionary(t => t.Key, t => t.Value);
            Dictionary<string, int> topTenWords = sorter.TopResults(dictionary).ToDictionary(t => t.Key, t => t.Value);
            string[] actualTopTenWords = topTenWords.Keys.ToArray();

            Console.WriteLine("The most used word is: " + actualTopTenWords[0]);
            Console.ReadLine();

            sorter = null;
            parser = null;
            
        }
    }
}
