using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扫雷
{
    class Program
    {
        const int width = 30;
        const int height = 16;
        static Player player = new Player();
        static ConsoleCanvas canvas = null;
        static char[,] buffer = null;
        static ConsoleColor[,] color_buffer = null;
        public static string below_text = "";
        public static string level_target = "";
        public static string record_text = "";
        public static void record_file()
        {
            // 记录
        }


        public const int minesweeper = 99; // 雷数
        //public const int li = 16; // 高
        //public const int lj = 30; // 宽
        static int[,] initMine()
        {
            int[,] mine = randomMap.generateMap(height, width, minesweeper);
            return mine;
        }

        static void DrawOther(int[,] Mine)  // 显示
        {
            for (int i = 0; i < Mine.GetLength(0); i++)
            {
                for (int j = 0; j < Mine.GetLength(1); j++)
                {
                    if (Mine[i, j] == -1)
                    {
                        color_buffer[i, j] = ConsoleColor.Red;
                        buffer[i, j] = '*';
                    }
                    else if (Mine[i, j] > -1)
                    {
                        color_buffer[i, j] = ConsoleColor.DarkYellow;
                        buffer[i, j] = (char)(Mine[i, j] + '0');
                    }
                    else if (Mine[i ,j] == -10)
                    {
                        color_buffer[i, j] = ConsoleColor.Green;
                        buffer[i, j] = 'x';// 标记
                    }
                    else
                    {
                        color_buffer[i, j] = ConsoleColor.Gray;
                        buffer[i, j] = '-';
                    }
                }
            }
            color_buffer[player.i, player.j] = ConsoleColor.Green;
            buffer[player.i, player.j] = '@';
        }

        static void DrawAll(int[,] Mine)  // 显示
        {
            canvas.ClearBuffer_DoubleBuffer();
            DrawOther(Mine);
            DrawBelowInfo();
            canvas.Refresh_DoubleBuffer();
            
        }

        static void DrawBelowInfo()
        {
            for (int i = 0; i < below_text.Length; ++i)
            {
                buffer[height, i] = below_text[i];
            }
            for (int i = 0; i < level_target.Length; i++)
            {
                buffer[height+1, i] = level_target[i];
            }
        }

        static int InputNum() // 读取输入
        {
            int count = -1;// 标记或者选择
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.I)
            {
                if (player.i > 0)
                {
                    player.i -= 1;
                }
            }
            else if (key.Key == ConsoleKey.K)
            {
                if (player.i < width - 1)
                {
                    player.i += 1;
                }
            }
            else if (key.Key == ConsoleKey.J)
            {
                if (player.j > 0)
                {
                    player.j -= 1;
                }
            }
            else if (key.Key == ConsoleKey.L)
            {  
                if (player.j < width - 1)
                {
                    player.j += 1;
                }
            }
            else if (key.Key == ConsoleKey.U)
            {
                // 标记当前
                count = 0;
            }
            else if (key.Key == ConsoleKey.A)
            {
                // 打开当前
                count = 1; 
            }
            return count;
        }


        static bool StartGame(int[,] mine, int[,] userMine)
        {
            int i = player.i;
            int j = player.j;

            if (mine[i, j] == 0)
            {
                // 处理 0 及周围
                JudgeZero(mine, i, j, userMine);
            }
            else if (mine[i, j] == -1)
            {
                // 为雷时退出
                userMine[i, j] = mine[i, j];
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
        static bool GameOver(int[,] userMine, int[,] Mine)
        {
            DrawAll(userMine);
            int blank = 0;
            for (int i = 0; i < userMine.GetLength(0); i++)
            {
                for (int j = 0; j < userMine.GetLength(1); j++)
                {
                    if (userMine[i, j] >= 0 ) 
                    {
                        blank++;
                    }
                }
            }
            if (blank == (height * width - minesweeper))// 点开所有数字
            {
                return true;
            }
            return false;
        }

        static int[,] InitUser(int lengthi, int lengthj) // 初始化玩家的地图 
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

            int flag = minesweeper;
            canvas = new ConsoleCanvas(width, height+3);
            buffer = canvas.GetBuffer();
            color_buffer = canvas.GetColorBuffer();
            player.SetPos(0, 0); // 默认位置

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); // 计算用时
            int[,] mine = initMine();
            int[,] saveMine = SaveMap(mine);
            int[,] userMine = InitUser(mine.GetLength(0), mine.GetLength(1));


            bool b = true;
            string res = "不好意思，您输了。下次走运！";
            sw.Start(); // 计时开始
            while (b)
            {
                below_text = "按U标记,按A打开,按IJKL移动";
                level_target = $"当前雷数{minesweeper},剩余标记{flag}";
                DrawAll(userMine); // 显示棋盘
                int count = InputNum();
                if (count == 1)
                {
                    b = StartGame(mine, userMine); // 
                    if (GameOver(userMine, saveMine))
                    {
                        res = "恭喜！您赢了！";
                        break;
                    }
                }
                else if (count == 0)
                {
                    if (userMine[player.i, player.j] != -10 && userMine[player.i, player.j] < 0)
                    {
                        userMine[player.i, player.j] = -10;
                        flag--;
                    }
                    else if (userMine[player.i, player.j] == -10)
                    {
                        userMine[player.i, player.j] = -2;
                        flag++;
                    }
                } 
            }
            sw.Stop(); // 计时结束
            canvas.ClearBuffer_DoubleBuffer();
            DrawOther(saveMine);
            canvas.Refresh_DoubleBuffer();
            Console.WriteLine();
            Console.Write(res);
            Console.WriteLine("时间：{0} 秒", sw.ElapsedMilliseconds / 1000);
            Console.ReadLine();
        }
    }

    class Player
    {
        public int i;
        public int j;

        public void SetPos(int _i, int _j)
        {
            i = _i;
            j = _j;
        }
    }
}
