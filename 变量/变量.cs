using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BianLiang
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 写程序将” Hello World”打印到屏幕。
            Console.WriteLine("1. 写程序将” Hello World”打印到屏幕。");
            Console.WriteLine("Hello World");


            // 2. 写程序输入用户的姓名并用该姓名和他打招呼。（输入张三，则输出Hello 张三!）
            Console.WriteLine("\n2.写程序输入用户的姓名并用该姓名和他打招呼。（输入张三，则输出Hello 张三!）");
            string name;
            name = Console.ReadLine();
            Console.WriteLine("Hello " + name + "!");
            //if (name == "张三" || name == "小明") {
            //    Console.WriteLine("Hello " + name + "!");
            //}


            // 3. 输入两个变量a和b，交换a和b的值。（变量里的值要真的交换，不只是在屏幕上显示交换）
            Console.WriteLine("\n3. 输入两个变量a和b，交换a和b的值。（变量里的值要真的交换，不只是在屏幕上显示交换）");
            string a;
            string b;

            Console.WriteLine("输入 a 的值: ");
            a = Console.ReadLine();
            Console.WriteLine("输入 b 的值: ");
            b = Console.ReadLine();
            // 交换
            string soo = a;
            a = b;
            b = soo;
            // 输出
            Console.WriteLine("交换 a、b 值之后");
            Console.WriteLine("a :" + a);
            Console.WriteLine("b :" + b);


            Console.ReadKey();
        }
    }
}
