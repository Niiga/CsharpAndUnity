using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_New5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // 6. 修改上个程序，使得求和的数只包含3或5的倍数，例如n=17，则求和的数为：3, 5, 6, 9, 10, 12, 15。

            // 读取整数输入
            Console.WriteLine("输入整数 n：");
            int n = Convert.ToInt32(Console.ReadLine());

            int sum = 0; // 求和
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
                if (i%3==0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.Write(sum);


            Console.ReadKey();
        }
    }
}
