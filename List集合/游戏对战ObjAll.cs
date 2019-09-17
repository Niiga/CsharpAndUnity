using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 游戏对战
{
    class ObjAll: Program
    {
        public string name;
        public float HP; // 血量
        public float AttackPower;// 攻击力
        public float Defense; // 防御
        public int deNumber; // 无视防御等级 0 为最大 \ 20 为最小
        public float Critical; // 暴击
        public float CriticalDemage;// 暴击伤害

        public ObjAll(string _name)
        {
            name = _name;

        }

        public float Attack(Player player, Random random)
        {
            float attck = (AttackPower - (Defense * deNumber));
            int roll = random.Next(0, 100);
            if (roll < Critical)
            {
                attck *= CriticalDemage;
            }
            return attck;
        }
    }
}
