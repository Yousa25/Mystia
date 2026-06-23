using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegate
{
    public delegate void CookDish(string dishname);
    public delegate void BigTransactionHandler(decimal amount);


    public class Reimu
    {
        public decimal amount = 200;

        public void CollectTax(decimal amount)
        {
            Console.WriteLine($"灵梦付了{amount}元,应交税{(double)amount*0.2}");
        }
    }

    public class Marisa
    {
        public decimal amount = 7000;

        public void CollectTax(decimal amount)
        {
            Console.WriteLine($"魔理沙付了{amount}元,应交税{(double)amount * 0.2}");
        }
    }

    public class Sanae
    {
        public decimal amount = 1000;

        public void CollectTax(decimal amount)
        {
            Console.WriteLine($"早苗付了{amount}元,应交税{(double)amount * 0.2}");
        }
    }

    /// <summary>
    /// 多功能烧烤架
    /// </summary>
    public class MultifunctionalGrill
    {
        public static void Grill(string ingredient, Func<string, string> seasoningAction)
        {
            Console.WriteLine("正在烤制");
            Console.WriteLine(seasoningAction($"{ingredient}"));
        }

        public string ApplySauce(string ingredient)
        {
            return $"正在给{ingredient}加酱汁";
        }

        public string SprinkleCumin(string ingredient)
        {
            return $"正在给{ingredient}撒孜然";
        }

        public void CookDish(string dishName)
        {
            Console.WriteLine($"正在烤制{dishName}~");
            Thread.Sleep(10000);
            Console.WriteLine($"{dishName}烤制完成");
        }
    }

    public class YuyukoOrder
    {
        public string OrderFood(string mainFood, string drink = null, string dessert = null)
        {
            string yuyuko = $"幽幽子点单如下，主食：{mainFood},饮料：{drink},甜点:{dessert}";

            Action<string> action = new Action<string>(KitchenOrder);
            action += CheckoutRecord;
            action(yuyuko);
            return $"幽幽子点单如下，主食：{mainFood},饮料：{drink},甜点:{dessert}";
        }

        public void KitchenOrder(string orderMessage)
        {
            Console.WriteLine("后厨收到" + orderMessage);
        }
        public void CheckoutRecord(string orderMessage)
        {
            Console.WriteLine("收银台收到" + orderMessage);
        }

    }

        
    internal class Program
    {

        static void Main(string[] args)
        {
            // 项目1
            //1.定义一个 Func<string, string> 类型的委托，代表“调料加工方法”（传入食材名，返回加工后的描述）
            //    MultifunctionalGrill multifunctionalGrill = new MultifunctionalGrill();

            //    Func<string, string> func1 = multifunctionalGrill.ApplySauce;
            //    Func<string, string> func2 = new Func<string, string>(multifunctionalGrill.SprinkleCumin);

            //    string ingredient = "烤八目鳗";
            //    MultifunctionalGrill.Grill(ingredient, func1);
            //    MultifunctionalGrill.Grill(ingredient, func2);
            //}


            // 项目2
            //YuyukoOrder yuyukoOrder = new YuyukoOrder();
            //yuyukoOrder.OrderFood(mainFood:"饭团",dessert:"普通小蛋糕");

            //项目3
            //MultifunctionalGrill multifunctionalGrill = new MultifunctionalGrill();
            ////multifunctionalGrill.CookDish("烤八目鳗");
            //CookDish cookdish = new CookDish(multifunctionalGrill.CookDish) ;
            //Console.WriteLine("客人：那边的夜雀好像好好吃~");
            //cookdish.BeginInvoke("烤八目鳗",null,null);
            //Console.WriteLine("米斯蒂娅：我是店员！！！！");
            
            //cookdish.EndInvoke(cookdish.BeginInvoke("烤八目鳗", null, null));


            //项目4
            Reimu reimu = new Reimu();
            Marisa marisa = new Marisa();
            Sanae sanae = new Sanae();
            // 初始化委托链
            BigTransactionHandler bigTransactionHandler = null;
            // 魔理沙和灵梦在场
            Console.WriteLine("灵梦和魔理沙进入夜雀食堂");
            bigTransactionHandler += reimu.CollectTax;
            bigTransactionHandler += marisa.CollectTax;
            //使用?.Invoke可以保证委托链为空时不报错
            bigTransactionHandler?.Invoke(2000);
            // 魔理沙被灵梦打飞
            Console.WriteLine("灵梦打飞了魔理沙");
            bigTransactionHandler -=marisa.CollectTax;
            Console.WriteLine("早苗进入夜雀食堂");
            bigTransactionHandler += sanae.CollectTax;
            bigTransactionHandler?.Invoke(2000);
        }


    }

}
