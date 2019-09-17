using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringCopy
{
    class Program
    {
        static void stringCopy()
        {
            // public static string Copy(string str);
            string strA = "将被复制";
            string strB = String.Copy(strA);
            Console.WriteLine(strB);

            // public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
            // sourceIndex 需要复制的字符的起始位置
            // destination 目标字符数组(_被粘贴的字符串_)
            // destinationIndex 制定目标数组中的开始存放位置
            // count 指定要复制的字符个数
            string str1 = "1234567890";
            char[] str2 = new char[100]; 
            str1.CopyTo(0, str2, 0, str1.Length);
            // str1 被复制的字符串

            Console.WriteLine(str2);

        }

        static void repStr()
        {
            // public string Replace(char OChar, char NChar);
            // public string Replace(string OValue, string NValue);
            // OChar/OValue 待替换的字符/字符串
            // NChar/NValue 替换后的新字符/新字符串
            string str = "one world, one dream";
            string rep = str.Replace(',', '!');
            Console.WriteLine(rep);

        }

        static void Main(string[] args)
        {
            

            Console.ReadKey();
        }
    }
}
