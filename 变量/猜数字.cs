using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaiShuZi
{
    class Program
    {
        static int inputNum()
        {
            int n;
            while(true)
            {
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("输 入 错 误， 请 重 新 输 入 ： ");
                }
            }
        }

        static int getRandom()
        {
            Random ramdom = new Random();
            int roll = ramdom.Next(1, 101);

            return roll;
        }

        static void CaiShuZi(int roll)
        {
            int num = 0; // 计数器

            while (true)
            {
                int inputnum = inputNum();

                num++;
                if (inputnum == roll)
                {
                    Console.WriteLine("你猜对了，一共猜了{0}次，还不错。", num);
                    break;
                } else if (inputnum > roll)
                {
                    Console.WriteLine("太大了");
                } else if (inputnum < roll)
                {
                    Console.WriteLine("太小了");
                }
            }
        }

        static void Main(string[] args)
        {
            CaiShuZi(getRandom());

            Console.ReadKey();
        }
    }
}
