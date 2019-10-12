using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txtdemo
{
    class CountWords
    {
        /*
         * 按要求存储可用单词
         */
        public ArrayList Splitwords(string text)
        {
            ArrayList al = new ArrayList();
            MatchCollection matchs = Regex.Matches(text, @"\b[a-zA-Z]{4,}\w*");
            foreach (Match match in matchs)
            {
                al.Add(match.Value);
            }
            return al;
        }

        public ArrayList Splitlenth(int lenth, string text)
        {
            string b = lenth.ToString();
            string pattern = "\\b\\w{"+b+"}\\s";
            ArrayList al = new ArrayList();
            MatchCollection matchs = Regex.Matches(text, pattern);
            foreach (Match match in matchs)
            {
                al.Add(match.Value);
            }
            return al;
        }

        public int Sumword(ArrayList al)
        {
            int sum = 0;
            foreach(var word in al)
            {
                sum++;
            }
            return sum;
        }

        /*
         * 统计每个单词出现的次数
         */
        public Dictionary<string, int> countWords(ArrayList arrayList)
        {
            Dictionary<string, int> nary = new Dictionary<string, int>();

            foreach (string word in arrayList)
            {
                if (nary.ContainsKey(word))
                {
                    nary[word]++;
                }
                else
                {
                    nary.Add(word, 1);
                }
            }
            return nary;
        }

        /*
         * 按值排序
         */
        public Dictionary<string, int> sort(Dictionary<string, int> nary)
        {
            var result = from pair in nary orderby pair.Value descending, pair.Key ascending select pair;
            Dictionary<string, int> bronary = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> pair in result)
            {
                bronary.Add(pair.Key, pair.Value);
            }
            return bronary;
        }
    }
}
