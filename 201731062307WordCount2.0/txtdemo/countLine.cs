using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txtdemo
{
   public class CountLine
    {
        /*
         * 统计非空白行数
         */
        public int CountLines(string text)
        {
            int lines = 0;
            lines = Regex.Matches(text, @"\r").Count + 1;
            return lines;
        }
    }
}
