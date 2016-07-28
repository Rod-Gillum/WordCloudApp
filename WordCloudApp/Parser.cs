using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCloudApp
{
    public class Parser : IParser
    {
        // TODO: would place these in enums or configs if it was more than notational.
        private readonly char[] _delimiters = { ',',' ','.',':',';','\t' };
        private readonly List<string> _blackListedWords = new List<string> {"a", "an", "the", "it", "us", "them", "i", "to", "in", "of", "for", "and"};

        /// <summary>
        /// The parser splits the passed in file on the defined delimiters.
        /// </summary>
        /// <returns>A dictionary with the words as the keys and the number of usages as the values.</returns>
        public IDictionary<string, int> ParseFile(string path)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            using (StreamReader reader = new StreamReader(path))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] parts = line.Split(_delimiters);
                    foreach (var part in parts)
                    {                       
                        if (string.IsNullOrEmpty(part)) continue;
                        string word = part.ToLower();
                        if (IsInvalid(word)) continue;

                        if (dictionary.ContainsKey(word))
                        {
                            dictionary[word]++;
                        }
                        else
                        {
                            dictionary[word] = 1;
                        }
                    }
                }
            }
            return dictionary;
        }

        /// <summary>
        /// Determines if the word needs to be filtered out.
        /// </summary>
        /// <param name="word">The passed in string.</param>
        /// <returns>False if word is valid.</returns>
        private bool IsInvalid(string word)
        {
            return WordIsPunctuation(word) || IsOnBlackList(word);
        }

        /// <summary>
        /// Verifies the word is not a single punctuation mark.
        /// </summary>
        /// <param name="word">The passed in string.</param>
        /// <returns>True if the string is a single character of punctuation.</returns>
        private static bool WordIsPunctuation(string word)
        {
            bool isPunctuation = false;
            if (word.Length == 1)
            {
                if (char.IsPunctuation(word[0]))
                {
                    isPunctuation = true;
                }
            }
            
            return isPunctuation;
        }

        /// <summary>
        /// Checks to see is this is a word that is useless to a word cloud.
        /// </summary>
        /// <param name="word">The passed in string.</param>
        /// <returns>True if the string is a matches a blacklisted word.</returns>
        private bool IsOnBlackList(string word)
        {       
            return _blackListedWords.Any(w => w.Equals(word));
        }

    }
}
