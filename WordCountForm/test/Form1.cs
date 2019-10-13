using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordCountClassLibrary;

namespace test
{
    public partial class Form1 : Form
    { 
        Dictionary<string,int> nary=new Dictionary<string,int>();
        WordCount wordCount = new WordCount();
        ArrayList al = new ArrayList();
        int sumchar = 0;
        int sumword = 0;
        int ZDYcount=10;//自定义高频输出数量
        int CZcount = 0;//自定义词组长度
        bool click;
        public Form1()
        {
            InitializeComponent();

        }
        //输入单词进行词频统计分析
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 0 && textBox9.TextLength != 0)
            {
                if (click == true&&textBox5.TextLength == 0)
                {
                    sumchar = wordCount.characSum(textBox1.Text.ToString());
                    al = wordCount.Splitwords(textBox1.Text.ToString());
                    //textBox8.AppendText(al.Capacity.ToString());
                    int i = 0;
                    while (i <= (al.Count - CZcount))
                    {
                        var result = al.GetRange(i, CZcount);
                        foreach (var n in result)
                        {
                            textBox8.AppendText(n.ToString() + " ");
                        }

                        textBox8.AppendText("\r\n");
                        i++;
                    }


                    sumword = wordCount.Sumword(al);
                    nary = wordCount.countWords(al);
                    textBox3.AppendText(sumchar.ToString());
                    textBox4.AppendText(sumword.ToString());
                    foreach (var pair in nary.Take(ZDYcount))
                    {
                        textBox2.AppendText(pair.Key + "：" + pair.Value);
                        textBox2.AppendText("\r\n");
                    }
                }
                else if(textBox1.TextLength==0&&click==true)
                {
                    MessageBox.Show("已导入");
                }
                else
                {
                    MessageBox.Show("请点击自定义");
                }
            }
            else
            {
                MessageBox.Show("请输入两个需要的数字");
            }
        

        }


        //统计导入文件词频
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.TextLength != 0&&textBox9.TextLength != 0)
            {
                if (click == true&&textBox1.TextLength==0)
                {
                    string Pdfpath = "";
                    OpenFileDialog op = new OpenFileDialog();
                    op.Filter = "word Files(*.txt)|*.txt|All Files(*.*)|*.*";
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        Pdfpath = op.FileName;
                    }
                    else
                    {
                        Pdfpath = "";
                    }
                    textBox5.Text = Pdfpath;

                    string text = File.ReadAllText(Pdfpath).ToLower();
                    sumchar = wordCount.characSum(text);
                    al = wordCount.Splitwords(text);//获取所有单词的集合

                    int i = 0;
                    while (i <= (al.Count - CZcount))
                    {
                        var result = al.GetRange(i, CZcount);
                        foreach (var n in result)
                        {
                            textBox8.AppendText(n.ToString() + " ");
                        }

                        textBox8.AppendText("\r\n");
                        i++;
                    }

                    sumword = wordCount.Sumword(al);
                    nary = wordCount.countWords(al);
                    textBox3.AppendText(sumchar.ToString());
                    textBox4.AppendText(sumword.ToString());
                    foreach (var pair in nary.Take(ZDYcount))
                    {
                        textBox2.AppendText(pair.Key + "：" + pair.Value);
                        textBox2.AppendText("\r\n");
                    }
                }
                else if (textBox5.TextLength == 0 && click == true)
                {
                    MessageBox.Show("已导入");
                }
                else
                {
                    MessageBox.Show("请点击自定义");
                }

            }
            else
            {
                MessageBox.Show("请输入两个所需数字");
            }
        }

        private void button3_Click(object sender, EventArgs e)//导出按钮
        {
            string Outpath = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "word Files(*.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                Outpath = op.FileName;
            }
            else
            {
                Outpath = "";
            }
            textBox6.Text = Outpath;
            try
            {
                StreamWriter str = new StreamWriter(Outpath, true);
                str.WriteLine("总字符数：" + sumchar);
                str.WriteLine("单词数：" + sumword);
                foreach (var pair in nary.Take(ZDYcount))
                {
                    str.WriteLine(pair.Key + "：" + pair.Value);
                }
                str.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("文件写入失败！");
            }
        }
        private void button4_Click_1(object sender, EventArgs e)//自定义按钮
        {
            click = true;
            if (textBox9.TextLength != 0)
            {
                CZcount = int.Parse(textBox9.Text);
            }
            if (textBox7.TextLength != 0)
            {
                ZDYcount = int.Parse(textBox7.Text);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        } 
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
