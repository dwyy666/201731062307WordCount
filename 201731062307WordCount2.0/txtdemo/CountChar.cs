using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace txtdemo
{
    public class CountChar
    {
        /*
        * 统计所有字符个数
        */
        public int characSum(string text)
        {
            int sum = 0;
            
            sum = text.Length;
            //sum += Regex.Matches(text, @"\w").Count;
            //sum += Regex.Matches(text, @"\s").Count;
            return sum;
        }
    }
}
