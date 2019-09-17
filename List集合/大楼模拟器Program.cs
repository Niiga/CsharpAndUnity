using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大楼模拟器
{
    class Program
    {
        public const int aircraftHeight = 10;
        static List<int> InputNum() // 当输入为西南角、东南角、西北角、东北角坐标
        {
            Console.WriteLine("请输入西南角、东南角、西北角、东北角坐标(用逗号或空格隔开)：");
            char[] separ = { ' ', ',' };
            string[] splits = Console.ReadLine().Split(separ);
            List<int> length = new List<int>();
            for (int i = 0; i < splits.Length; i++)
            {
                length.Add(int.Parse(splits[i]));
            }

            return length;
        }

        static List<int> InputNum(bool bl) // 当输入为西南角 宽度-东西向 南北向
        {
            Console.WriteLine("请输入西南角 宽度-东西向 南北向(用逗号或空格隔开)：");
            char[] separ = { ' ', ',' };
            string[] splits = Console.ReadLine().Split(separ);
            List<int> length = new List<int>();
            for (int i = 0; i < splits.Length; i++)
            {
                length.Add(int.Parse(splits[i]));
            }

            return length;
        }

        static void Start()
        {
            List<int> length1 = new List<int> { 4, 1, 4, 5, 1, 1, 1, 5 };
            // 西北 1,1   东北 1,5
            // 西南 4,1   东南 4,5
            List<int> length2 = new List<int> { 4, 5, 4, 5 };
            // 西南 4,5  宽(东西向) 4    宽(南北向) 5 
            List<int> length3 = new List<int> { 5, 5, 6, 6 };
            // 西南 5,5  宽(东西向) 6    宽(南北向) 6
            Building mansion1 = new Building(length1);
            Building mansion2 = new Building(length2, true);
            NewBuild newMansion = new NewBuild(length3, 9);

            List<Building> City = new List<Building>();
            City.Add(mansion1);
            City.Add(mansion2);
            City.Add(newMansion);

            Console.WriteLine("一共有 {0} 座大楼。", City.Count);
            for (int i = 0; i < City.Count; i++)
            {
                Console.Write("大楼{0}的", i+1);
                if (City[i].GetType() == typeof(NewBuild))
                { // GetType 获取类型 typeof(类型)
                   
                    City[i].area(City[i].Height);
                    if (City[i].Height < aircraftHeight)
                    {
                        Console.WriteLine("飞机能够安全从大楼上方通过。");
                    }
                    else
                    {
                        Console.WriteLine("飞机不能安全从大楼上方通过。");
                    }
                }
                else
                {
                    City[i].area();
                } 
            }
            
            
        }

        static void Main(string[] args)
        {
            Start();

            Console.WriteLine("请按任意键继续. . .");
            Console.ReadKey();
        }
    }
}
