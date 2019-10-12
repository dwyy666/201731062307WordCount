using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txtdemo
{
    class CountChar
    {
        /*
        * 统计所有字符个数
        */
        public long characSum(string text)
        {
            long sum = 0;
            sum += Regex.Matches(text, @"\w").Count;
            sum += Regex.Matches(text, @"\s").Count;
            return sum;
        }
    }
}
