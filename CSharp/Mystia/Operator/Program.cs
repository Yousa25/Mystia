using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// 1. 基础算术：卖出30个饭团，每个5元
            //int riceBallCount = 30;
            //int riceBallPrice = 5;

            //Console.WriteLine($"今日饭团卖了{riceBallCount*riceBallPrice}元");

            //// 2. 取模运算(%)：客人给了158元，需要找零多少？
            //Console.WriteLine($"用取模运算可以得出要给客人{158%(riceBallPrice*riceBallCount)}元，我就当小费收下咯！");


            //// 3. 复合赋值运算符(+=)：小碎骨突然往塞钱箱里投了1000块
            //int donationBox = 1;

            //donationBox += 1000;
            //if ( donationBox > 1000 ) {
            //    Console.WriteLine("以前怎么没发现老板娘这么眉清目秀");
            //}

            int marisaFavorability = 85; // 魔理沙当前好感度
            int unlockThreshold = 80;    // 解锁隐藏菜单所需好感度

            // 1. 大于等于(>=)：够不够格吃隐藏菜？
            bool canUnlockMenu = marisaFavorability >= unlockThreshold;
            Console.WriteLine($"魔理沙能解锁隐藏菜单吗: {canUnlockMenu}"); // 输出: True

            // 2. 不等于(!=)：检查幽幽子是不是还没离开摊位
            string currentGuest = "西行寺幽幽子";
            bool isNotEmpty = currentGuest != "";
            Console.WriteLine($"摊位上有客人吗: {isNotEmpty}"); // 输出: True
        }
    }
}
