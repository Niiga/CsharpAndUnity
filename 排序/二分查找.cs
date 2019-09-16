using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二分查找
{
    class Program
    {
        static int InputNum()
        {
            Console.WriteLine("要查找的数字：");
            int n;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out n))
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("输入错误，请重新输入数字：");
                }
            } 
        }

        static int searchNums(int[] nums, int number)
        {
            int head = 0;
            int tail = nums.Length;
            int mid;


            while (head < tail)
            {
                mid = (head + tail) / 2;
                if (number == nums[mid])
                {
                    return mid;

                }
                else if (number < nums[mid])
                {
                    tail = mid - 1;
                }
                else if (number > nums[mid])
                {
                    head = mid + 1;
                }
            }

            return -1;

        }

        static void Main(string[] args)
        {
            int[] nums = new int[]
            {
                11,22,33,42,54,65,76,81,93,101,102,103,104,111,122,133
            };

            int n = InputNum();
            int number = searchNums(nums, n);
            if (number >= 0)
            {
                Console.WriteLine("找到了, {0} 在数组 nums 的 {1} 位上", n, number);
            } else
            {
                Console.WriteLine("没有找到您输入的数。");
            }

            Console.ReadKey();
        }
    }
}
