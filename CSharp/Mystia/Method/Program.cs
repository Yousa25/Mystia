using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    //创建一个博丽灵梦的类
    public class ShrineMaiden
    {
        public string Name { get; set; }
        public int Money { get; set; }
        
        //初始化为无名，金钱为0
        public ShrineMaiden()         
        {
            this.Name = "无名";
            this.Money = 0;
        
        }

        public ShrineMaiden(string Name,int Money)
        {
            this.Name = Name;
            this.Money = Money;

        }
    }

    public class MystiaKitchen
    {
        public void Cook(string ingredient)
        {
            Console.WriteLine($"米斯蒂娅使用了{ingredient}制作了料理");

        }

        public void Cook(string ingredient,int count)
        {
            Console.WriteLine($"米斯蒂娅使用了{count}份{ingredient}制作了料理");
        }
    }
    internal class Program
    {
      

        static void Main(string[] args)
        {
            //ShrineMaiden shrineMaiden = new ShrineMaiden("博丽灵梦",20);
            //Console.WriteLine(shrineMaiden.Name);
            //Console.WriteLine(shrineMaiden.Money);

            MystiaKitchen mystiaKitchen = new MystiaKitchen();
            mystiaKitchen.Cook("海苔");

            mystiaKitchen.Cook("鸡蛋", 100);
        }
    }
}
