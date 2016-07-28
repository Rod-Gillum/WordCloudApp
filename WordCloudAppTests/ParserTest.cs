using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCloudApp;

namespace WordCloudAppTests
{
    [TestClass]
    public class ParserTest
    {
        private Parser _parser;
        private string _testPath1;
        private int _validWordsInResume = 278;
        private string _sixthWordInResume = "baltimore";
        private int _occurancesOfTwentySixthWordInResume = 4;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new Parser();
            _testPath1 = "../../Resume.txt";
        }

        [TestCleanup]
        public void Cleanup()
        {
            _parser = null;
        }

        [TestMethod]
        public void TestResumeDocWordCount()
        {
            Dictionary<string, int> actual = _parser.ParseFile(_testPath1).ToDictionary(t => t.Key, t => t.Value);
            int expected = _validWordsInResume;
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestResumeDocSixthWord()
        {
            Dictionary<string, int> actual = _parser.ParseFile(_testPath1).ToDictionary(t => t.Key, t => t.Value);
            string expected = _sixthWordInResume;
            string[] actualWords = actual.Keys.ToArray();
            Assert.AreEqual(expected, actualWords[5]);
        }

        [TestMethod]
        public void TestResumeDocTwentySixthWord()
        {
            Dictionary<string, int> actual = _parser.ParseFile(_testPath1).ToDictionary(t => t.Key, t => t.Value);
            int expected = _occurancesOfTwentySixthWordInResume;
            int[] actualWords = actual.Values.ToArray();
            Assert.AreEqual(expected, actualWords[25]);
        }
    }
}
