using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Format
{
    class Program
    {
        static void FormatDt()
        // 格式化输出
        {
            // string strA = "gg";
            // string strB = "Game";
            // Console.WriteLine(String.Format("{0},{1}!!!", strA, strB));
            // gamer,Game!!!

            DateTime dt = DateTime.Now; // 获得当前日期
            string strD = String.Format("{0:D}|{1:T}", dt, dt); // 小写 d 为简短时间
            //string strT = String.Format("{0:T}", dt);
            //string strF = String.Format("{0:F}", dt);
            //string strG = String.Format("{0:G}", dt);
            //string strM = String.Format("{0:M}", dt);
            //string strY = String.Format("{0:Y}", dt);
            Console.WriteLine(strD);
            //Console.WriteLine(strT);
            //Console.WriteLine(strF);
            //Console.WriteLine(strG);
            //Console.WriteLine(strM);
            //Console.WriteLine(strY);
        }

        static void SubStr()
        // 截取字符串
        {
            string strA = "我将要被截断一一一一一一一截";
            string strB = "接收";
            strB = strA.Substring(2, 4); // (开始， 长度)
            Console.WriteLine(strB);
            // strB = strA[2]+strA[3]+strA[4]+strA[5]
        }

        static void splitStr()
        {
            // public string[] Split(params char[] separator);
            string str = "G:\\String\\格式化\\Format\\Format\\bin\\Debug\\Format.exe";
            char[] separator = { ':', '\\', '.' };
            String[] splits = new string[100];
            splits = str.Split(separator);

            // 得到的splits为：
            // { "G",
            //   "",
            //   "String", 
            //   "格式化", 
            //   "Format", 
            //   "Format", 
            //   "bin", 
            //   "Debug", 
            //   "Format", 
            //   "exe" }
        }


        static void Main(string[] args)
        {
            // public string Insert(int statIndex, string value);
            
            
            Console.ReadKey();
        }
    }
}
