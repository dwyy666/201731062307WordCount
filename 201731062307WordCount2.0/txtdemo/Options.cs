using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace txtdemo
{
    class Options
    {
        [Option('o', MetaValue = "FILE", Required = true, HelpText = "数据源输入路径")]
        public string output { get; set; }

        [Option('i', MetaValue = "FILE", Required = true, HelpText = "需要处理的文件。")]
        public string input { get; set; }

        [Option('m', MetaValue = "Word", Required = false, HelpText = "词组")]
        public string size { get; set; }

        [Option('n', MetaValue = "MaxWord", Required = false, HelpText = "指定输出个数")]
        public string number { get; set; }
    }
}
