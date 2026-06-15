using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NightSparrowCanteen
{
    internal class Program
    {
        public class Mystia
        {
            public string Name { get; set; } = "Mystia";

            public int CookingLevel { get; set; } = 1;
            // 耐力
            public double Stamina { get; set; } = 100.0;

            public void MystiaSong ()
            {
                Console.WriteLine( "夜雀之歌");
            }
            public void ThrowDishes ()
            {
                Console.WriteLine("投掷上菜");
            }
        }

        public enum dishTag
        {
            Japanese,//和风
            Chinese,//中华
            Wester,//西式
        }

        public struct Ingredient
        {
            public string Name { get; set; }
            public int Price { get; set; }
        }

        public class Menu
        {
            public dishTag Tag { get; set; }
            public Ingredient Ingredient { get; set; }

            public void DishInfo()
            {
                Console.WriteLine($"{Ingredient.Name}是{Tag}，价格为{Ingredient.Price}");
            }
        }

        static void Main(string[] args)
        {
            
            //Mystia mystiaType = new Mystia();

            //Console.WriteLine("米斯蒂娅的属性");
            //PropertyInfo[] propertyInfos = mystiaType.GetType().GetProperties();
            //foreach (PropertyInfo propertyInfo in propertyInfos)
            //{
            //    Console.WriteLine( propertyInfo.Name );
            //}
            //MethodInfo[] methodInfos = mystiaType.GetType().GetMethods();
            //Console.WriteLine("米斯蒂娅的能力");
            //foreach (MethodInfo methodInfo in methodInfos)
            //{
            //    Console.WriteLine( methodInfo.Name );
            //}

            Menu menu = new Menu();
            menu.Ingredient = new Ingredient { Name="饭团",Price=1};
            menu.Tag = dishTag.Japanese;

            menu.DishInfo();
                                 
        }
    }
}
