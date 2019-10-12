using Microsoft.VisualStudio.TestTools.UnitTesting;
using txtdemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txtdemo.Tests
{
    [TestClass()]
    public class CountLineTests
    {
        [TestMethod()]
        public void CountLinesTest()
        {
            string test = @"There once was a young horse named Mary
                               This Mary was rather quite hairy1
                               She blow-dried her hair
                               And now she's quite bare
                               Now she has less hair to carry!";
            CountLine countLine = new CountLine();
            Assert.AreEqual(countLine.CountLines(test), 5);
        }
        [TestMethod()]
        public void CountLines2Test()
        {
            string text = @"Love is more than a word，
                                 it says so much.
                                When I see these four letters,
                                I almost feel your touch.
                                This is only happened since，
                                I fell in love with you.
                                Why this word does this,
                                I haven't got a clue.";
            CountLine countLine = new CountLine();
            Assert.AreEqual(countLine.CountLines(text), 8);
        }
        [TestMethod()]
        public void CountLines3Test()
        {
            string text = @"aaaaaaaa";
            CountLine countLine = new CountLine();
            Assert.AreEqual(countLine.CountLines(text), 1);
        }
    }
}