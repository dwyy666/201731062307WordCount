using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCountClassLibrary
{
    public class WordCount
    {
        /*
         * 统计所有字符个数
         */
        public int characSum(string text)
        {
            int sum = 0;
            //sum += Regex.Matches(text, @"\w").Count;
            //sum += Regex.Matches(text, @"\s").Count;
            sum = text.Length;
            return sum;
        }

        /*
         *功能类，取出满足要求的单词 
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

        //计算单词总数
        public int Sumword(ArrayList al)
        {
            int sum = 0;
            foreach (var word in al)
            {
                sum++;
            }
            return sum;
        }
        /*
        * 统计每个单词出现的次数，并按要求排序
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
