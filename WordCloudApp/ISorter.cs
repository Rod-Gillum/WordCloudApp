using System.Collections.Generic;

namespace WordCloudApp
{
    public interface ISorter
    {
        /// <summary>
        /// Grabs the most used words in the file.
        /// </summary>
        /// <param name="dictionary">The passed in index of words.</param>
        /// <param name="numberOfResults">The number of returned results, the default is 10.</param>
        /// <returns>The most used words as the keys and number of usages as the values.</returns>
        IDictionary<string, int> TopResults(IDictionary<string, int> dictionary, int numberOfResults);

        /// <summary>
        /// Identifies words used in a range of occurrences.
        /// </summary>
        /// <param name="dictionary">The passed in index of words.</param>
        /// <param name="minResults">The minimum number of occurrences allowed in the set.</param>
        /// <param name="maxResults">The maximum number of occurrences allowed in the set.</param>
        /// <returns></returns>
        IDictionary<string, int> ThresholdResults(IDictionary<string, int> dictionary, int minResults, int maxResults);
    }
}
