using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 统计字符出现次数
{
    class Program
    {
        static void seekStr(int[] nums, string str)
        {
            
            for (int i = 0; i < str.Length; i++)
            {
                int j = 0;
                for ( ; j < i; j++)
                {
                    if (str[j] == str[i])
                    {
                        nums[j]++;
                        break;
                    }
                }
                if (j == i)
                    nums[j]++;
            }
        }

        static void printNumstr(int[] nums, string str)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i] != 0 && str[i] != ' ')
                {
                    Console.WriteLine(str[i] + "\t" + nums[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int[] nums = new int[str.Length];

            seekStr(nums, str);
            printNumstr(nums, str);

            Console.ReadKey();
        }
    }
}
