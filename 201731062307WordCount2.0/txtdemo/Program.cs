using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;
using CommandLine;
using CommandLine.Text;
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
        static string FilePath = "";
        static string outputPath = "";
        static int Size=3;
        static int Number=10;
        private static void Run(Options options)
        {
            if (options.input != null)
            {
                FilePath = options.input.ToString();
            }
            if (options.output != null)
            {
                outputPath = options.output.ToString();
            }
            if(options.size!=null)
            {
                Size = int.Parse(options.size);
            }
            if (options.number != null)
            {
                Number = int.Parse(options.number);
            }
        }
        static void Main(string[] args)
        {

            var options = new Options();
            Parser.Default.ParseArguments<Options>(args).WithParsed(Run);
            //Console.WriteLine(FilePath);
            string text = File.ReadAllText(FilePath).ToLower();//读取txt文件

            CountLine countLine = new CountLine();
            int lines = countLine.CountLines(text);//行数
            Console.WriteLine("Lines：{0}", lines);

            CountChar countChar = new CountChar();
            int charnum = countChar.characSum(text);//字符数
            Console.WriteLine("Characters：{0}", charnum);

            CountWords countWords = new CountWords();
            ArrayList al = countWords.Splitwords(text);

            


            //ArrayList bl = countWords.Splitlenth(3, text);//限定长度

            //单词总数
            int sum = countWords.Sumword(al);
            Console.WriteLine("Wordnumber：{0}", sum);

            //输出最高词频单词，默认前10，可以根据命令行更改个数
            Console.WriteLine("-----------------------输出最高词频单词，命令行配置初始化为前10---------------------------------------------");
            Dictionary<string, int> nary = countWords.countWords(al);
            nary = countWords.sort(nary);
            foreach (KeyValuePair<string, int> entry in nary.Take(Number))
            {
                string word = entry.Key;
                int frequency = entry.Value;
                StreamWriter stream = new StreamWriter(outputPath, true);
                stream.WriteLine(word + frequency);
                stream.Close();
                Console.WriteLine("{0}:{1}", word, frequency);
            }


            //附加功能，输出指定长度词组，默认为0.
            if (Size != 0)
            {
                Console.WriteLine("-----------------------输出指定长度词组，命令行配置初始化为3---------------------------------------------");
                Dictionary<string, int> test = new Dictionary<string, int>();
                test = countWords.msort(al, Size);
                foreach (var pair in test)
                {
                    Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
                }
            }


            //Console.WriteLine("-----------------------小组附加功能：输出指定长度单词，默认为3--------------------------------------");

            //额外添加功能，输出指定长度的单词
            //Dictionary<string, int> damn = countWords.countWords(bl);
            //foreach (KeyValuePair<string, int> fire in damn)
            //{
            //    Console.WriteLine("{0}:{1}", fire.Key, fire.Value);
            //}

        }
    }
}
