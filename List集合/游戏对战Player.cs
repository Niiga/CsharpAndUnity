using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 游戏对战
{
    class Player
    {
        public string name; // 天马
        public int deNumber; // 无视防御等级 0 为最大，20 为最小
        public float HP;
        // public float AttackSpeed = 1.0f; // 攻击速度
        public float AttackPower; // 攻击力
        public float Defense; // 防御
        public float Critical; // 暴击
        public float CriticalDemage; // 暴击伤害

        public Player(string _name)
        {
            name = _name;
            deNumber = 10;
            HP = 20000;
            AttackPower = 4000f;
            Defense = 100;
            Critical = 60 * 0.01f;
            CriticalDemage = 200 * 0.01F;
        }

        public float Attack(ObjAll other, Random random)
        {
            float attck = (AttackPower - (other.Defense * deNumber));
            int roll = random.Next(0, 100);
            if (roll < Critical)
            {
                attck *= CriticalDemage;
            }

            return attck;
        }
    }
}
