using System.Collections.Generic;
using System.Linq;

namespace WordCloudApp
{
    public class Sorter : ISorter
    {
        /// <summary>
        /// Grabs the most used words in the file.
        /// </summary>
        /// <param name="dictionary">The passed in index of words.</param>
        /// <param name="resultsPerPage">The number of returned results, default is 10.</param>
        /// <returns>The most used words as the keys and number of usages as the values.</returns>
        public IDictionary<string, int> TopResults(IDictionary<string, int> dictionary, int resultsPerPage = 10)
        {
            return SortByCount(dictionary).Take(resultsPerPage).ToDictionary(t => t.Key, t => t.Value);
        }

        /// <summary>
        /// Identifies words used in a range of occurrences.
        /// </summary>
        /// <param name="dictionary">The passed in index of words.</param>
        /// <param name="minResults">The minimum number of occurrences allowed in the set.</param>
        /// <param name="maxResults">The maximum number of occurrences allowed in the set.</param>
        /// <returns>the most used words</returns>
        public IDictionary<string, int> ThresholdResults(IDictionary<string, int> dictionary, int minResults, int maxResults)
        {
            return SortByCount(dictionary).Where(t => t.Value >= minResults && t.Value <= maxResults).ToDictionary(t => t.Key, t => t.Value);
        }

        /// <summary>
        /// Sorts by word usage decending.
        /// </summary>
        /// <param name="dictionary">The passed in index of words.</param>
        /// <returns>The sorted key value pair.</returns>
        private static IEnumerable<KeyValuePair<string, int>> SortByCount(IDictionary<string, int> dictionary)
        {
            return from entry in dictionary orderby entry.Value descending select entry;
        }
    }
}
