using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @params
{
    public class MystiaShop
    {
        public void Restock(params string[] ingredients)
        {
            if(ingredients.Count()<=0)
            {
                Console.WriteLine("小碎骨今天没进货");
            }
            else
            {
                Console.WriteLine("进货成功");
                foreach (var item in ingredients)
                {
                    Console.Write($"{item}、");
                }
            }
        }
    }
    public class ReimuWallet
    {
        // ref 参数：传入一个已经初始化的变量，方法内对它的修改会直接影响外部
        public void SpendMoney(ref int banlance , int cost)
        {
            banlance -= cost;

        }
        // out 参数：调用前可以不初始化，但方法内部必须给它赋值（通常用于返回多个结果）
        public void CheckWalletCapacity(out int max)
        {
            max = 99999;

        }
    }

    public class YuyukoOrder
    {
        public void PlaceOrder(string dishName,bool spice = false,string note = "无特殊要求")
        {
            Console.WriteLine($"点单： {dishName}|是否加辣： {spice}|备注： {note}");

        }
    }

    // 扩展方法必须放在静态类中
    public static class StringExtensions
    {
        // 第一个参数使用 this 修饰，表示我们要扩展 string 类型
        public static bool IsVipGuest(this string guestName)
        { 
            if (guestName =="博丽灵梦"|| guestName=="西行寺幽幽子")
            return true;

            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //MystiaShop mystiaShop = new MystiaShop();

            //string[] ingredients = new string[] { "八目鳗","豆腐","萝卜" };
            //mystiaShop.Restock(ingredients);

            //ReimuWallet wallet = new ReimuWallet();
            //// 1. 测试 ref：调用前必须初始化 balance
            //int reimu = 200;
            //wallet.SpendMoney(ref reimu, 20);
            //Console.WriteLine(reimu);
            //// 2. 测试 out：调用前无需初始化
            //wallet.CheckWalletCapacity(out int max);
            //Console.WriteLine(max);

            //YuyukoOrder yuyukoOrder = new YuyukoOrder();
            //yuyukoOrder.PlaceOrder(note:"要高级料理",dishName:"烤八目鳗");

   
            Console.WriteLine("博丽灵梦".IsVipGuest());
            
            
        }
    }
}
