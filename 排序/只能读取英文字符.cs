using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 只能读取字符
{
    class Program
    {
        static void seekStr(int[] nums, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                nums[str[i]]++;
            }
        }

        static void printNumstr(int[] nums, string str)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0 && (char)i != ' ')
                {
                    Console.WriteLine((char)i + "\t" + nums[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int[] nums = new int['z' + 1];

            seekStr(nums, str);
            printNumstr(nums, str);

            Console.ReadKey();
        }
    }
}
