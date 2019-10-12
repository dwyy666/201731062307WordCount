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
    public class CountCharTest
    {
        [TestMethod()]
        public void characSumTest()
        {
            string text = @"Love is more than a word，
                                 it says so much.
                                When I see these four letters,
                                I almost feel your touch.
                                This is only happened since，
                                I fell in love with you.
                                Why this word does this,
                                I haven't got a clue.";
            string test = @"There once was a young horse named Mary
                               This Mary was rather quite hairy1
                               She blow-dried her hair
                               And now she's quite bare
                               Now she has less hair to carry!";
            CountChar countChar = new CountChar();
            countChar.characSum(text);
            countChar.characSum(test);
            Assert.AreEqual(countChar.characSum(text), 423);
            Assert.AreEqual(countChar.characSum(test), 279);
        }

        [TestMethod()]
        public void characSumTest1()
        {
            string text = @"aaaaaaaa";
            CountChar countChar = new CountChar();
            countChar.characSum(text);
            Assert.AreEqual(countChar.characSum(text), 8);
        }
        [TestMethod()]
        public void characSumTest2()
        {
            string text = @"bbbbbbbb";
            CountChar countChar = new CountChar();
            countChar.characSum(text);
            Assert.AreEqual(countChar.characSum(text), 8);
        }
    }
}