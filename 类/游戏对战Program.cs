using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 游戏对战
{
    
    class Program
    {
        static Random random = new Random();
        static int enemyNumber = 0; // 已死亡的怪物数

        static ObjAll initEnemy1()
        {
            ObjAll zy = new ObjAll("朱厌");
            zy.deNumber = 10; // 无视防御等级( 0 最大、20 最小 )
            zy.HP = 4000; // 血量
            zy.AttackPower = 4500f;// 攻击力
            zy.Defense = 40f; // 防御
            zy.Critical = 70f; // 暴击几率
            zy.CriticalDemage = 280 * 0.01F; // 暴击伤害

            return zy;
        }

        static ObjAll initEnemy2()
        {
            ObjAll si = new ObjAll("兕");
            si.deNumber = 12;
            si.HP = 5000;
            si.AttackPower = 3500f;
            si.Defense = 60f;
            si.Critical = 75f;
            si.CriticalDemage = 175 * 0.01f;

            return si;
        }

        static void Akk(ObjAll enemy, Player player)
        { // 怪物攻击
            
            float attack = enemy.Attack(player, random);
            float a = enemy.AttackPower - (player.Defense * enemy.deNumber);
            player.HP -= attack;

            if (attack > a)
            {
                Console.Write("【{0}】对【{1}】产生暴击", enemy.name, player.name);
            }
            else
            {
                Console.Write("【{0}】对【{1}】", enemy.name, player.name);
            }
            Console.Write("造成 {0} 点伤害", attack);
            if (player.HP > 0)
            {
                Console.WriteLine("，当前生命{0}", player.HP);
            } else
            {
                Console.WriteLine ("，当前生命 0");
            }
        }

        static void Akk(Player player, ObjAll enemy)
        { // 玩家攻击
            float attack = player.Attack(enemy, random);
            float a = player.AttackPower - (player.Defense * enemy.deNumber);
            enemy.HP -= attack;

            if (attack > a)
            {
                if (attack > a)
                {
                    Console.Write("【{0}】 对 【{1}】 产生暴击", player.name, enemy.name);
                }
                else
                {
                    Console.Write("【{0}】 对 【{1}】 ", player.name, enemy.name);
                }
                Console.WriteLine("造成 {0:0} 点伤害", attack);
            }
        }


        static bool GameOver(ObjAll Enemy)
        {
            
            bool bl = true;
            if (Enemy.HP <= 0)
            {
                enemyNumber++;
                Enemy.HP = 0;
                Console.WriteLine("【{0}】 已死亡", Enemy.name);
            }
            if (enemyNumber == 2)
            {
                bl = false;
            }
            return bl;
        }

        static bool GameOver(Player me)
        {
            bool bl = true;
            if (me.HP <= 0)
            {
                bl = false;
                me.HP = 0;
                Console.Write("【{0}】 已死亡", me.name);
            }
            return bl;
        }

        static void startGame()
        {
            ObjAll enemy1 = initEnemy1();
            ObjAll enemy2 = initEnemy2();

            string name = "你";
            Player me = new Player(name);

            do
            {
                Console.WriteLine("【{0}】 对 【{1}】【{2}】发起了攻击", me.name, enemy1.name, enemy2.name);
                Akk(me, enemy1);
                if (!GameOver(enemy1))
                {
                    Console.WriteLine("您已击杀所有妖怪。");
                    return;
                }
                Akk(me, enemy2);
                if (!GameOver(enemy2))
                {
                    Console.WriteLine("您已击杀所有妖怪。");
                    return;
                }
                Console.WriteLine("【{0}】【{1}】 对 【{2}】发起了攻击", enemy1.name, enemy2.name, me.name);
                Akk(enemy1, me);
                if (!GameOver(me))
                {
                    Console.WriteLine("\n你死了，游戏结束");
                    break;
                }
                Akk(enemy2, me);
                if (!GameOver(me))
                {
                    Console.WriteLine("\n你死了，游戏结束");
                    break;
                }
            } while (me.HP >= 0);
            
        }

        static void Main(string[] args)
        {
            
            startGame();
            Console.WriteLine("游戏结束");

            Console.WriteLine("请按任意键退出. . .");
            Console.ReadKey();
        }
    }
}
