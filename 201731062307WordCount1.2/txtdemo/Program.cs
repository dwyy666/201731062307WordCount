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
            //string input = Console.ReadLine();//输入
            //string[] inputstr = input.Split(' ');//将输入分成两个小块
            //string path = inputstr[1];//取文件名，文件创建在debug文件夹里
            //string start = inputstr[0];
            string FilePath = "";
            string outputPath = "";

            var arguments = CommandLineArgumentParser.Parse(args);
            var ar = arguments.Get("-i");
            var arr = arguments.Get("-o");
            if (ar != null)
            {
                if (ar.Take() != null)
                {
                    FilePath = ar.Take();
                }
            }
            if (arr != null)
            {
                if (arr.Take() != null)
                {
                    outputPath = arr.Take();
                }
            }


            string text = File.ReadAllText(FilePath).ToLower();//读取txt文件

            CountLine countLine = new CountLine();
            int lines = countLine.CountLines(text);//行数
            Console.WriteLine("Lines：{0}", lines);

            CountChar countChar = new CountChar();
            long charnum = countChar.characSum(text);//字符数
            Console.WriteLine("Characters：{0}", charnum);

            CountWords countWords = new CountWords();
            ArrayList al = countWords.Splitwords(text);//前十

            ArrayList bl = countWords.Splitlenth(5, text);//限定长度
            int sum = countWords.Sumword(al);
            Console.WriteLine("Wordnumber：{0}", sum);
            /*
            Dictionary<string, int> damn = countWords.countWords(bl);
            foreach(KeyValuePair<string,int> fire in damn)
            {
                Console.WriteLine("{0}:{1}", fire.Key, fire.Value);
            }*/

            Console.WriteLine("------------------------------分割线-------------------------------");

            Dictionary<string, int> nary = countWords.countWords(al);
            nary = countWords.sort(nary);
            foreach (KeyValuePair<string, int> entry in nary.Take(10))
            {
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}:{1}", word, frequency);
            }

        }
    }
}
