using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扫雷
{
    class Program
    {

        public const int minesweeper = 99; // 雷数
        public const int li = 16; // 高
        public const int lj = 30; // 宽
        static int[,] initMine()
        {
            int[,] mine = randomMap.generateMap(li, lj, minesweeper);
            return mine;
        }

        static void OutMine(int[,] Mine)  // 显示
        {
            for (int i = 0; i <= Mine.GetLength(1); i++)
            {
                if (i > 0)
                {
                    Console.Write("{0,2} ", i);
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < Mine.GetLength(0); i++)
            {
                Console.Write("{0,-2}", i + 1);
                for (int j = 0; j < Mine.GetLength(1); j++)
                {
                    if (Mine[i, j] == -1)
                    {
                        Console.Write(" * ");
                    }
                    else if (Mine[i, j] > -1)
                    {
                        Console.Write("{0,2} ", Mine[i, j]);
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }

        static int[] InputNum() // 读取输入
        {
            char[] separ = { ' ' };
            Console.WriteLine("扫雷游戏棋盘如上，请输入位置(格式为：数字空格数字)：");
            int[] length = new int[2]; // 存储输入的i j

            bool b;
            do
            {
                b = false;
                string[] splits = Console.ReadLine().Split(separ);

                if (int.TryParse(splits[0], out length[0]) && int.TryParse(splits[1], out length[1]))
                {
                    length[0]--;
                    length[1]--;
                }
                else
                {
                    Console.WriteLine("输入有误， 请重新输入：");
                    b = true;
                }
                if (length[0] < 0 || length[0] > li || length[1] < 0 || length[1] > lj)
                {
                    Console.WriteLine("输入有误， 请重新输入：");
                    b = true;
                }
            } while (b);

            return length;
        }


        static bool StartGame(int[,] mine, int[,] userMine)
        {
            int[] length = InputNum();
            int i = length[0];
            int j = length[1];

            if (mine[i, j] == 0)
            {
                // 处理 0 及周围
                JudgeZero(mine, i, j, userMine);
            }
            else if (mine[i, j] == -1)
            {
                // 为雷时退出
                return false;
            }
            else if (mine[i, j] > 0)
            {
                userMine[i, j] = mine[i, j];
            }

            return true;
        }

        static void JudgeZero(int[,] mine, int i, int j, int[,] userMine)
        {
            userMine[i, j] = 0;

            if (i - 1 >= 0) // 前边界
            {
                if (mine[i - 1, j] == 0)
                {
                    mine[i - 1, j] = -2;
                    JudgeZero(mine, i - 1, j, userMine);
                    userMine[i - 1, j] = 0;
                }
                else if (userMine[i - 1, j] == -2)
                {         // 0 周围的数字 不可能为-1(雷)
                    userMine[i - 1, j] = mine[i - 1, j];
                }
            }
            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (mine[i - 1, j - 1] == 0)
                {
                    mine[i - 1, j - 1] = -2;
                    JudgeZero(mine, i - 1, j - 1, userMine);
                    userMine[i - 1, j - 1] = 0;
                }
                else if (userMine[i - 1, j - 1] == -2)
                {
                    userMine[i - 1, j - 1] = mine[i - 1, j - 1];
                }
            }
            if (i - 1 >= 0 && j + 1 < mine.GetLength(1))
            {
                if (mine[i - 1, j + 1] == 0)
                {
                    mine[i - 1, j + 1] = -2;
                    JudgeZero(mine, i - 1, j + 1, userMine);
                    userMine[i - 1, j + 1] = 0;
                }
                else if (userMine[i - 1, j + 1] == -2)
                {
                    userMine[i - 1, j + 1] = mine[i - 1, j + 1];
                }
            }
            if (i + 1 < mine.GetLength(0)) // 后边界
            {
                if (mine[i + 1, j] == 0)
                {
                    mine[i + 1, j] = -2;
                    JudgeZero(mine, i + 1, j, userMine);
                    userMine[i + 1, j] = 0;
                }
                else if (userMine[i + 1, j] == -2)
                {
                    userMine[i + 1, j] = mine[i + 1, j];
                }
            }
            if (i + 1 < mine.GetLength(0) && j + 1 < mine.GetLength(1))
            {
                if (mine[i + 1, j + 1] == 0)
                {
                    mine[i + 1, j + 1] = -2;
                    JudgeZero(mine, i + 1, j + 1, userMine);
                    userMine[i + 1, j + 1] = 0;
                }
                else if (userMine[i + 1, j + 1] == -2)
                {
                    userMine[i + 1, j + 1] = mine[i + 1, j + 1];
                }
            }
            if (i + 1 < mine.GetLength(0) && j - 1 >= 0)
            {
                if (mine[i + 1, j - 1] == 0)
                {
                    mine[i + 1, j - 1] = -2;
                    JudgeZero(mine, i + 1, j - 1, userMine);
                    userMine[i + 1, j - 1] = 0;
                }
                else if (userMine[i + 1, j - 1] == -2)
                {
                    userMine[i + 1, j - 1] = mine[i + 1, j - 1];
                }
            }
            if (j - 1 >= 0) // 前边界
            {
                if (mine[i, j - 1] == 0)
                {
                    mine[i, j - 1] = -2;
                    JudgeZero(mine, i, j - 1, userMine);
                    userMine[i, j - 1] = 0;
                }
                else if (userMine[i, j - 1] != 0)
                {
                    userMine[i, j - 1] = mine[i, j - 1];
                }
            }
            if (j + 1 < mine.GetLength(1)) // 后边界
            {
                if (mine[i, j + 1] == 0)
                {
                    mine[i, j + 1] = -2;
                    JudgeZero(mine, i, j + 1, userMine);
                    userMine[i, j + 1] = 0;
                }
                else if (userMine[i, j + 1] == -2)
                {
                    userMine[i, j + 1] = mine[i, j + 1];
                }
            }
        }
        static bool GameOver(int[,] userMine)
        {
            OutMine(userMine);
            int blank = 0;
            for (int i = 0; i < userMine.GetLength(0); i++)
            {
                for (int j = 0; j < userMine.GetLength(1); j++)
                {
                    if (userMine[i, j] == -2) // 未点开的空白处
                    {
                        blank++;
                        // Console.WriteLine("{0} , {1}  blank{2}", i, j, blank);
                    }
                }
            }
            if (blank == minesweeper)// 未点开的"空白处"等于"雷数" 游戏结束
            {
                return true;
            }
            return false;
        }

        static int[,] initUser(int lengthi, int lengthj) // 保存的玩家地图 初始化
        {
            int[,] newMine = new int[lengthi, lengthj];
            for (int i = 0; i < lengthi; i++)
            {
                for (int j = 0; j < lengthj; j++)
                {
                    newMine[i, j] = -2;
                }
            }
            return newMine;
        }

        static int[,] SaveMap(int[,] mine)
        {
            int[,] save = new int[mine.GetLength(0), mine.GetLength(1)];
            for (int i = 0; i < mine.GetLength(0); i++)
            {
                for (int j = 0; j < mine.GetLength(1); j++)
                {
                    save[i, j] = mine[i, j];
                }
            }
            return save;
        }

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); // 计算用时
            int[,] mine = initMine();
            int[,] saveMine = SaveMap(mine);
            int[,] userMine = initUser(mine.GetLength(0), mine.GetLength(1));

            // OutMine(saveMine);
            // OutMine(userMine);

            bool b = true;
            string res = "不好意思，您输了。下次走运！";
            sw.Start(); // 计时开始
            while (b)
            {
                OutMine(userMine);
                b = StartGame(mine, userMine); // 判断输入是否为 雷
                if (GameOver(userMine))
                {
                    res = "恭喜！您赢了！";
                    break;
                }
                Console.Clear();
            }
            sw.Stop(); // 计时结束

            Console.Clear();
            OutMine(saveMine);
            Console.WriteLine(res);
            Console.WriteLine("时间：{0} 秒", sw.ElapsedMilliseconds / 1000);

            Console.ReadKey();
        }
    }
}
