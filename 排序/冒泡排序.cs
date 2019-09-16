using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 冒泡排序
{
    class Program
    {
        static void sortNums(int[] nums)
        // 冒泡排序
        {
            for (int j = nums.Length-1; j >= 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (nums[i] > nums[i+1])
                        exNums(nums, i, i+1);
                }
            }
        }

        static void exNums(int[] nums, int i, int j)
        // 交换
        {

            int exchange = nums[i];
            nums[i] = nums[j];
            nums[j] = exchange;
        }

        static int[] randomNums()
        // 生成随机数
        {
            Random random = new Random();
            int[] nums = new int[10];
            for (int i = 0; i < 10; i++)
            {
                nums[i] = random.Next(1, 101);
            }

            return nums;
        }

        static void printNums(int[] nums)
        // 打印数组内容
        {
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] nums = new int[10];
            nums = randomNums();
            sortNums(nums);
            printNums(nums);

            Console.ReadKey();
        }
    }
}
