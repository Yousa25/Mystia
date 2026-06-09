using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceVariableAndInstance
{
    public class Izakaya
    {
        public static string OpeningHours = "20:00-00:00";
    }
    public class Youkai
    {
        public string Name { get; set; }

        public int walletBalence { get; set; }

        public void ShowName()
        {
            Console.WriteLine(this.Name);
        }
    }

    public class Dish
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public bool IsReady { get; set; }

        public void Cook()
        {
            IsReady = true;

            Console.WriteLine("滋滋作响的烤八目鳗出炉了");

            OnCookingCompeleted.Invoke();
        }

        public event Action OnCookingCompeleted;


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region OldCode
            //////Youkai mystia = new Youkai();
            //////mystia.Name = "Mystia";
            //////mystia.ShowName();

            //////(new Youkai()).Name="幽幽子";
            //////(new Youkai()).ShowName();

            ////Youkai youkai = new Youkai();
            ////youkai.Name = "西行寺幽幽子";
            ////youkai.ShowName();

            ////Youkai anotner = youkai;

            ////anotner.Name = "贪吃的亡灵";
            ////youkai.ShowName();

            //Dish dish = new Dish();
            //dish.Name = "烤八目鳗";
            //dish.Price = 100;

            //dish.OnCookingCompeleted += () => Console.WriteLine("服务员幽谷响子：收到！马上端给客人！");

            //dish.Cook();
            #endregion

            Youkai chen = new Youkai();
            chen.Name = "橙";
            chen.walletBalence = 1000;
            Youkai riggle = new Youkai();
            riggle.Name = "莉格露";
            riggle.walletBalence = 500;

            Console.WriteLine($"{chen.Name}的余额是{chen.walletBalence}\n");
            Console.WriteLine($"{riggle.Name}的余额是{riggle.walletBalence}\n");

            Console.WriteLine($"营业时间是{Izakaya.OpeningHours}");


        }
    }

    
}


