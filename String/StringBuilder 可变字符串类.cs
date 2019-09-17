using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 可变字符串类
{
    class Program
    {
        static void changeStr()
        {
            // (string value, int cap)
            StringBuilder MySb = new StringBuilder("MySb1");
            int num = 99;
            string str = "Nooono";
            // Append 将文本或字符串追加到指定对象的末尾
            // AppendFormat 自定义变量的格式并将这些值追加到 StringBuilder 对象的末尾
            // Insert 将字符串或对象添加到当前 StringBuilder 对象中的指定位置
            // Remove 从当前 StringBuilder 对象中移除指定数量的字符
            // Replace 用另一个指定的字符来替换 StringBuilder 对象内的字符

            StringBuilder MySb1;
            MySb1 = MySb.Append("Append");
            Console.WriteLine("Append MySb1 ：" + MySb1);

            StringBuilder MySb2 = new StringBuilder("MySb2");
            MySb2.AppendFormat("AppendFormat");
            Console.WriteLine("AppendFormat MySb2 ：" + MySb2);

            StringBuilder MySb3 = new StringBuilder("MySb3");
            MySb3.Insert(1, "*Insert*");
            Console.WriteLine("Insert MySb3 ：" + MySb3);

            StringBuilder MySb4 = new StringBuilder("MySb4");
            MySb4.Remove(2, 1);
            Console.WriteLine("Remove MySb4(2,4) ：" + MySb4);

            StringBuilder MySb5 = new StringBuilder("MySb5 MySb5 MySb5");
            MySb5.Replace("MySb5", "*替换*");
            Console.WriteLine("Replace MySb5(\"MySb5MySb5MySb5\") ：" + MySb5);

        }


        static void Main(string[] args)
        {
            changeStr();

            Console.ReadKey();
        }
    }
}
