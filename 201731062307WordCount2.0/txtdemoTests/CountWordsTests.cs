using Microsoft.VisualStudio.TestTools.UnitTesting;
using txtdemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace txtdemo.Tests
{
    [TestClass()]
    public class CountWordsTests
    {
        [TestMethod()]
        public void SplitwordsTest()
        {
            string text = "aaaa bbbb cccc dddd";
            ArrayList al = new ArrayList();
            ArrayList bl = new ArrayList();
            al.Add("aaaa ");
            al.Add("bbbb ");
            al.Add("cccc ");
            al.Add("dddd ");
            CountWords countWords = new CountWords();
            bl = countWords.Splitwords(text);
            Assert.AreEqual(1 + 2, 3);
        }

        [TestMethod()]
        public void SumwordTest()
        {
            string text = "aaaa bbbb cccc dddd";
            CountWords countWords = new CountWords();
            ArrayList al = countWords.Splitwords(text);
            int sum = countWords.Sumword(al);
            Assert.AreEqual(sum, 4);
        }

        [TestMethod()]
        public void countWordsTest()
        {
            Dictionary<string, int> nary = new Dictionary<string, int>();
            string text = "aaaa bbbb cccc dddd";
            CountWords countWords = new CountWords();
            ArrayList al = countWords.Splitwords(text);
            nary = countWords.countWords(al);
            Assert.AreEqual(1 + 2, 3);

        }

        [TestMethod()]
        public void sortTest()
        {
            //
        }
    }
}