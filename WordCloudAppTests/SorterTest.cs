using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCloudApp;

namespace WordCloudAppTests
{
    [TestClass]
    public class SorterTest
    {
        private Parser _parser;
        private Sorter _sorter;
        private string _testPath;
        private Dictionary<string, int> _dictionary;
        private int _validWordsInResume = 278;
        private int _thresholdWordsInResume = 69;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new Parser();
            _sorter = new Sorter();
            _testPath = "../../Resume.txt";
            _dictionary = _parser.ParseFile(_testPath).ToDictionary(t => t.Key, t => t.Value);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _parser = null;
            _sorter = null;
            _dictionary = null;
        }


        [TestMethod]
        public void TestThresholdResultsHighWordCount()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 1, 1000).ToDictionary(t => t.Key, t => t.Value);
            int expected = _validWordsInResume;
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestThresholdResultsHighWordCountMax()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 1, 1000).ToDictionary(t => t.Key, t => t.Value);
            Assert.IsTrue(actual.Values.Max() <= 1000);
        }

        [TestMethod]
        public void TestThresholdResultsHighWordCountMin()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 1, 1000).ToDictionary(t => t.Key, t => t.Value);
            Assert.IsTrue(actual.Values.Min() >= 1);
        }

        [TestMethod]
        public void TestThresholdResultsLowWordCount()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 2, 4).ToDictionary(t => t.Key, t => t.Value);
            int expected = _thresholdWordsInResume;
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestThresholdResultsLowWordCountMax()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 2, 4).ToDictionary(t => t.Key, t => t.Value);
            Assert.IsTrue(actual.Values.Max() <= 4);
        }

        [TestMethod]
        public void TestThresholdResultsLowWordCountMin()
        {
            Dictionary<string, int> actual = _sorter.ThresholdResults(_dictionary, 2, 4).ToDictionary(t => t.Key, t => t.Value);
            Assert.IsTrue(actual.Values.Min() >= 2);
        }

        [TestMethod]
        public void TestResumeTopDefaultResultsCount()
        {
            Dictionary<string, int> actual = _sorter.TopResults(_dictionary).ToDictionary(t => t.Key, t => t.Value);
            int expected = 10;
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestResumeTopDefaultResultsTopResult()
        {
            Dictionary<string, int> actual = _sorter.TopResults(_dictionary).ToDictionary(t => t.Key, t => t.Value);
            string expected = "experience";
            Assert.AreEqual(expected, actual.First().Key);
        }

        [TestMethod]
        public void TestResumeTopPassedResultsCount()
        {
            Dictionary<string, int> actual = _sorter.TopResults(_dictionary, 8).ToDictionary(t => t.Key, t => t.Value);
            int expected = 8;
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestResumeTopPassedResultsBottomResult()
        {
            Dictionary<string, int> actual = _sorter.TopResults(_dictionary, 8).ToDictionary(t => t.Key, t => t.Value);
            string expected = "data";
            Assert.AreEqual(expected, actual.Last().Key);
        }

        [TestMethod]
        public void TopTen()
        {
            string[] expectedTopTenWords =
            {
                "experience",
                "my",
                "development",
                "sql",
                "framework",
                "crm",
                "reporting",
                "data",
                "using",
                "added",
            };

            Dictionary<string, int> actual = _sorter.TopResults(_dictionary).ToDictionary(t => t.Key, t => t.Value);
            string[] actualTopTenWords = actual.Keys.ToArray();
            Assert.AreEqual(expectedTopTenWords[0], actualTopTenWords[0]);
            Assert.AreEqual(expectedTopTenWords[1], actualTopTenWords[1]);
            Assert.AreEqual(expectedTopTenWords[2], actualTopTenWords[2]);
            Assert.AreEqual(expectedTopTenWords[3], actualTopTenWords[3]);
            Assert.AreEqual(expectedTopTenWords[4], actualTopTenWords[4]);
            Assert.AreEqual(expectedTopTenWords[5], actualTopTenWords[5]);
            Assert.AreEqual(expectedTopTenWords[6], actualTopTenWords[6]);
            Assert.AreEqual(expectedTopTenWords[7], actualTopTenWords[7]);
            Assert.AreEqual(expectedTopTenWords[8], actualTopTenWords[8]);
            Assert.AreEqual(expectedTopTenWords[9], actualTopTenWords[9]);
        }

    }
}
