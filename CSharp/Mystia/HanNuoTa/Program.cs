using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanNuoTa
{
    public class Cashier
    {
        public void PrintRecipt(string customerName)
        {
            Console.WriteLine($"欢迎来到夜雀食堂，{customerName}");
        }

        public double GetTaxRate()
        {
            return 0.1;
        }

        public double CalculateTotal(double price,int quantity)
        {
            return price*quantity*GetTaxRate()+price*quantity;
        }

        public void SweepLeaves(int remainingCount)
        {
            // 终止条件 叶子为0
            if (remainingCount == 0) {
                Console.WriteLine("打扫干净了");
            }

            Console.WriteLine($"呼哧...扫走了{remainingCount}片叶子");
            SweepLeaves(remainingCount - 1);
            
        }

        public int GetOnionCount(int layer)
        {
            Console.WriteLine($"正在计算第{layer}层洋葱");
            int count = 0;
            // 终止条件洋葱数为1
            if(layer == 1) {
                count = count + 1;
            }
            else
            {
                count = layer+GetOnionCount(layer-1);
            }

            return count;
        }

        /// <summary>
        /// x是碟子数目
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        /// 


        //public void HanNuoTa(int x,string start,string temp,string end)
        //{
        //    if(x == 1) {
        //        Console.WriteLine($"将盘子从{start}移到{end}上");
        //    }
        //    else
        //    {
        //        HanNuoTa(x-1,start,end,temp);
        //        Console.WriteLine($"将盘子从{start}移到{end}上");
        //        HanNuoTa(x - 1, temp, start, end);
        //    }

        //}

        int i = 1;
        public void HanNuoTa(int N,string start,string temp,string end)
        {
            // 记录进入当前层的状态
            Console.WriteLine($"[进入] N={N}, 起点:{start}, 中转:{temp}, 终点:{end}");
            if (N == 0)
            {
                return;
            }
            else
            {
                HanNuoTa(N - 1, start, end, temp);
                Console.WriteLine($"第{i++}次，{start}-->{end}");
                HanNuoTa(N - 1, temp, start, end);
            }
            // 记录离开当前层的状态
            Console.WriteLine($"[退出] N={N} 处理完毕");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "橙";
            int quanlity = 5;
            double dishPrice = 20;

            Cashier cashier = new Cashier();
            //定义三根柱子a,b,c
            string a, b, c;
            a = "A";//起始柱
            b = "B";//临时柱
            c = "C";//目标柱
            cashier.HanNuoTa(3, a, b, c);
            //Console.WriteLine(count);
        }
    }
}
