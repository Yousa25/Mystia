using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statement
{
    internal class Program
    {
        public enum UUZMode
        {
            好,
            一般,
            差
        }

        static void Main(string[] args)
        {
            //const int maxSeat = 8;
            //int currentGuest = 3;
            //int income = 0;

            //if (currentGuest<maxSeat)
            //{
            //    income = currentGuest * 400;
            //}
            //Console.WriteLine($"今日赚了{income}元");

            //for (int i = 0; i < 5; i++) {
            //    Console.WriteLine($"正在制作第{i+1}个饭团");
            //}
            //List<string> vipGuest = new List<string> { "博丽灵梦","琪露诺","红美铃","莉格露"};

            //for (int i = 0;i < vipGuest.Count;i++)
            //{
            //    Console.WriteLine($"给{vipGuest[i]}上一个饭团和十四夜");
            //}
            //UUZMode uUZMode = UUZMode.一般;
            //if (uUZMode==UUZMode.好)
            //{
            //    Console.WriteLine("十四夜");
            //}
            //else
            //{
            //    Console.WriteLine("绿茶");
            //}

            //UUZMode uUZMode = UUZMode.好;
            //switch (uUZMode)
            //{
            //    case UUZMode.好:
            //        Console.WriteLine("十四夜");
            //        break;
            //    case UUZMode.一般:
            //        Console.WriteLine("雀酒");
            //        break;
            //    case UUZMode.差:
            //        Console.WriteLine("绿茶");
            //        break;
            //    default:
            //        break;
            //}


            int[] bill = { 100, 10, 0, -10 };
            int income = 0;
            bool flag = true;
            for (int i = 0; i < bill.Length; i++)
            {
                if (bill[i] == 0) continue;

                if (bill[i] < 0)
                {
                    Console.WriteLine("有坏账");
                    flag = false;
                    break;
                }

                income += bill[i];
            }

            if (flag)
            {
                Console.WriteLine($"今日营业收入{income}");
            }
            else
            {
                Console.WriteLine("找灵梦告状");
            }

            // 2. try-catch-finally：处理做菜时的炸锅事故
            try
            {
                Console.WriteLine("正在猛火爆炒...");
                throw new Exception("灶台起火啦！"); // 模拟突发异常
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生异常: {ex.Message}，赶紧拿灭火器！");
            }
            finally
            {
                Console.WriteLine("无论是否起火，最后都要把灶台擦干净！"); // 必定执行
            }
        }
    }
}
