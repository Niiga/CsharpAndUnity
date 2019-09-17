using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大楼模拟器
{
    class Building
    {
        private int[] getWS = new int[2]; // 西南
        private int hw; // 东西向 竖 宽度
        private int ww; // 南北向 横 宽度 
        private int[] getWN; // 西北
        private int[] getES; // 东南
        private int[] getEN; // 东北
        private int height;
        List<int> coord = new List<int>();
        public List<int> Coord { get => coord; set => coord = value; }

        public int[] GetWS { get => getWS; set => getWS = value; }
        public int[] GetWN { get => getWN; set => getWN = value; }
        public int[] GetES { get => getES; set => getES = value; }
        public int[] GetEN { get => getEN; set => getEN = value; }
        
        public int Hw { get => hw; set => hw = value; }
        public int Ww { get => ww; set => ww = value; }

        public int Height { get => height; set => height = value; }

        public Building(List<int> _coord)
        {
            Coord = _coord;
            GetWS = new int[2] { coord[0], coord[1] };
            GetES = new int[2] { coord[2], coord[3] };
            GetWN = new int[2] { coord[4], coord[5] };
            GetEN = new int[2] { coord[6], coord[7] };
            Hw = getWS[0] - getWN[0];
            Ww = getES[1] - getWN[1];
            //area();
        }

        public Building(List<int> _coord, bool bl)
        {
            Coord = _coord;
            Hw = Coord[2];
            Ww = Coord[3];
            GetWS = new int[2] { coord[0], coord[1] };
            GetES = new int[2] { getWS[0], getWS[1] + ww };
            GetWN = new int[2] { getWS[0] - hw, getWS[1] };
            GetEN = new int[2] { getWS[0] - hw, getWS[1] + ww };
            //area();
        }

        public Building()
        {
        }

        public void area()
        {
            // 西南角、东南角、西北角、东北角
            Console.WriteLine("坐标为:");
            Console.WriteLine("西北({0},{1})\t\t 东北({2},{3})", getWN[0], getWN[1], getEN[0], getEN[1]);
            Console.WriteLine("西南({0},{1})\t\t 东南({2},{3})", getWS[0], getWS[1], getES[0], getES[1]);
            Console.WriteLine("占地面积为: {0}\n", hw * ww);
        }


        public void area(int height)
        {
            Console.WriteLine("大楼的坐标为:");
            Console.WriteLine("西北({0},{1})\t东北({2},{3})", GetWN[0], GetWN[1], GetEN[0], GetEN[1]);
            Console.WriteLine("西南({0},{1})\t东南({2},{3})", GetWS[0], GetWS[1], GetES[0], GetES[1]);
            Console.WriteLine("高为{0}，占地面积为: {1}\n", Height, Hw * Ww);
        }
    }

    class NewBuild : Building
    {
        public NewBuild(List<int> _coord, int _height)
            : base()
        {
            Height = _height;
            Coord = _coord;
            Hw = Coord[2];
            Ww = Coord[3];
            GetWS = new int[2] { Coord[0], Coord[1] };
            GetES = new int[2] { GetWS[0], GetWS[1] + Ww };
            GetWN = new int[2] { GetWS[0] - Hw, GetWS[1] };
            GetEN = new int[2] { GetWS[0] - Hw, GetWS[1] + Ww };
        }
    }
}
