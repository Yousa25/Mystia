using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /// <summary>
    /// 多功能烧烤架
    /// </summary>
    public class MultifunctionalGrill
    {
        public static void Grill(string ingredient ,Func<string,string> seasoningAction)
        {
            Console.WriteLine("正在烤制");
            Console.WriteLine(seasoningAction($"{ingredient}"));
        }

        public string  ApplySauce(string ingredient)
        {
            return $"正在给{ingredient}加酱汁";
        }

        public string SprinkleCumin(string ingredient)
        {
            return $"正在给{ingredient}撒孜然";
        }
    }

    public class YuyukoOrder
    {
        public string orderFood(string mainFood,string drink=null,string dessert=null)
        {
            return $"幽幽子点单如下，主食：{mainFood},饮料：{drink},甜点:{dessert}";
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            //1.定义一个 Func<string, string> 类型的委托，代表“调料加工方法”（传入食材名，返回加工后的描述）
            //    MultifunctionalGrill multifunctionalGrill = new MultifunctionalGrill();

            //    Func<string, string> func1 = multifunctionalGrill.ApplySauce;
            //    Func<string, string> func2 = new Func<string, string>(multifunctionalGrill.SprinkleCumin);

            //    string ingredient = "烤八目鳗";
            //    MultifunctionalGrill.Grill(ingredient, func1);
            //    MultifunctionalGrill.Grill(ingredient, func2);
            //}


            YuyukoOrder yuyukoOrder = new YuyukoOrder();
            string mainFood = "饭团";
            string drink = "十四夜";
            string dessert = "普通小蛋糕";
            Action<string,string,string> action1 = new Action<string, string, string>(yuyukoOrder.orderFood);
        }


    }
}
