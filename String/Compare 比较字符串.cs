using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1_Compare
{
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "gamer";
            string strB = "Gamer";
            Console.WriteLine(String.Compare(strA,strB,true)); // true 为忽略大小写差别
            // 相等 返回 0 
            // strA 大于 strB 返回  1 (比的是字典位置)
            // strA 小于 strB 返回 -1
            // String.Compare(strA, strB); ==> strA.CompareTo(strB); 
            Console.WriteLine(String.Equals(strA, strB)); // 返回 bool 值
            // 等于 strA.Equals(strB);
            // 区分大小写和区域性



            Console.ReadKey();
        }
    }
}
