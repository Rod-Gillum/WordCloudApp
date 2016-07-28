using System.Collections.Generic;

namespace WordCloudApp
{
    public interface IParser
    {
        /// <summary>
        /// Parses the file to form a dictionary of words with the number of times that they appear.
        /// </summary>
        /// <returns>Dictionary of word counts</returns>
        IDictionary<string, int> ParseFile(string path);
    }
}