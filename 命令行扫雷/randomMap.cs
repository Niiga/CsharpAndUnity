using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扫雷
{
    class randomMap
    {
        public static int[,] generateMap(int Lengthi, int Lengthj, int numberMine)
        {
            Random randij = new Random();
            int[,] Map = new int[Lengthi, Lengthj];
            while (numberMine > 0)
            { // 生成雷
                int rolli = randij.Next(0, Lengthi);
                int rollj = randij.Next(0, Lengthj);

                if (Map[rolli, rollj] != -1)
                {
                    Map[rolli, rollj] = -1;
                    numberMine--; 
                }
            }
            for (int i = 0; i < Lengthi; i++)
            {
                for (int j = 0; j < Lengthj; j++)
                {
                    if(Map[i,j] != -1)
                    {
                        Map[i, j] = AddNumberToMap(Map, i, j);
                    }
                }
            }
            return Map;
        }

        static int AddNumberToMap(int[,] Map, int i, int j)
        {
            int count = 0;

            if (i - 1 >= 0 && j - 1 >= 0)
            {
                if (Map[i - 1, j - 1] == -1) count++;
            }
            if (i - 1 >= 0)
            {
                if (Map[i - 1, j] == -1) count++;
            }
            if (i - 1 >= 0 && j + 1 < Map.GetLength(1))
            {
                if (Map[i - 1, j + 1] == -1) count++;
            }
            if (j - 1 >= 0)
            {
                if (Map[i, j - 1] == -1) count++;
            }
            if (j + 1 < Map.GetLength(1))
            {
                if (Map[i, j + 1] == -1) count++;
            }
            if (i + 1 < Map.GetLength(0) )
            {
                if (Map[i + 1, j] == -1) count++;
            }
            if (i + 1 < Map.GetLength(0) && j - 1 >= 0)
            {
                if (Map[i + 1, j - 1] == -1) count++;
            }
            if (i + 1 < Map.GetLength(0) && j + 1 < Map.GetLength(1))
            {
                if (Map[i + 1, j + 1] == -1) count++;
            }

            return count;
        }
    }
}
