using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;
/*
统计文件的字符数：
只需要统计Ascii码，汉字不需考虑
空格，水平制表符，换行符，均算字符
英文字母：A-Z，a-z
字母数字符号：A-Z，a-z，0-9
分割符：空格，非字母数字符号
例：file123是一个单词，123file不是一个单词。file，File和FILE是同一个单词
输出的单词统一为小写格式
统计文件的单词总数，单词：至少以4个英文字母开头，分隔符分割，不区分大小写。
统计文件的有效行数：任何包含非空白字符的行，都需要统计。
统计文件中各单词的出现次数，最终只输出频率最高的10个。频率相同的单词，优先输出字典序靠前的单词。
按照字典序输出到文件txt：例如，windows95，windows98和windows2000同时出现时，则先输出windows2000
*/
namespace txtdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();//输入
            string[] inputstr = input.Split(' ');//将输入分成两个小块
            string path = inputstr[1];//取文件名，文件创建在debug文件夹里

            string text = File.ReadAllText(path).ToLower();//读取txt文件

            int line = CountLines(text);//行数
            int charnum = characSum(text);//字符数
            Console.WriteLine("Lines：{0}", line);
            Console.WriteLine("Charnum：{0}", charnum);

            ArrayList al = countWords(text);

            Dictionary<string, int> nary = CountWords(al);

            nary=sort(nary);
           // compare(nary);
            foreach (KeyValuePair<string, int> entry in nary)
            {
                string word = entry.Key;
                int frequency = entry.Value;
                StreamWriter stream = new StreamWriter("output.txt", true);
                stream.WriteLine(word + frequency);
                stream.Close();
                Console.WriteLine("{0}:{1}", word, frequency);
            }
        }

        /*
         统计符合要求的单词数
        */
        static ArrayList countWords(string text)
        {
            int sum = 0;
            ArrayList al = new ArrayList();
            MatchCollection matchs = Regex.Matches(text, @"\b[a-zA-Z]{4,}\w*");
            foreach(Match match in matchs)
            {
                sum++;
                al.Add(match.Value);
            }
            Console.WriteLine("符合要求的单词总数：{0}", sum);
            return al;
        }

        /*
         * 统计每个单词出现的次数
         */
        static Dictionary<string, int> CountWords(ArrayList arrayList)
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
                    nary.Add(word,1);
                }
            }
            return nary;
        }

        /*
         * 按值排序
         */
        static Dictionary<string,int>  sort(Dictionary<string, int>nary)
        {
            var result = from pair in nary orderby pair.Value descending ,pair.Key ascending select pair;
            Dictionary<string, int> bronary = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> pair in result.Take(10))
            {
                bronary.Add(pair.Key, pair.Value);
            }
            return bronary;
        }

        //static void compare(Dictionary<string, int> nary)
        //{
        //    string tmp = String.Empty;
        //    int valueTmp = 0;
        //    string[] word = new string[nary.Count];
        //    int[] value = new int[nary.Count];
        //    int i = 0;
        //    foreach (KeyValuePair<string, int> pair in nary)
        //    {
        //        word[i] = pair.Key;
        //        value[i] = pair.Value;
        //        i++;
        //    }
        //    for (int k = 0; k < nary.Count - 1; k++)
        //    {
        //        for (int j = 1; j < nary.Count - 1; j++)
        //        {
        //            if (value[k] == value[j])
        //            {
        //                if (word[k].CompareTo(word[j]) == 1)
        //                {
        //                    tmp = word[k];
        //                    word[k] = word[j];
        //                    word[j] = tmp;
        //                    // Console.WriteLine(word[k] + "。。");
        //                    //Console.WriteLine(word[k + 1] + ".");
        //                }
        //            }
        //        }
        //    }
        //    string[] final = new string[nary.Count];
        //    for (int k = 0; k < nary.Count; k++)
        //    {
        //        final[k] = word[k] + ":" + value[k];
        //    }
        //    foreach (string str in final)
        //    {
        //        StreamWriter stream = new StreamWriter("output.txt", true);
        //        stream.WriteLine(str);
        //        stream.Close();
        //        Console.WriteLine("{0}", str);
        //    }
        //}

        /*
         * 统计非空白行数
         */
        static int CountLines(string text)
        {
            int lines = 0;
            lines = Regex.Matches(text, @"\r").Count+1;
            return lines;
        }

        /*
         * 统计所有字符个数
         */
        static int characSum(string text)
        {
            int sum = 0;
            sum += Regex.Matches(text, @"\w").Count;
            sum += Regex.Matches(text, @"\s").Count;
            return sum;
        }

    }
}
