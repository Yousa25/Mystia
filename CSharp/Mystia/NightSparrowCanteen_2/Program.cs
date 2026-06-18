using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightSparrowCanteen_2
{
    public class IngredientWarehouse
    {
        // 1. 静态字段：记录食堂的总营业天数，与具体某个仓库对象无关
        public static int TotalBusinessDays = 0;
        // 2. 私有实例字段：底层数据，外界不能直接访问
        private int riceStock;
        // 3. 自动属性：用于传递简单数据，编译器自动生成私有字段
        public string wareHouseName { get; set; }
        // 4. 完整属性：对私有字段进行封装，防止非法值污染
        public int RiceStock
        {
            get { return riceStock; }
            set {
                // 在设置值时进行逻辑验证，防止库存变成负数
                if (value >= 0)
                    riceStock = value;
                else
                    throw new Exception("被幽幽子偷吃了");
            
            }
        }
        // 5. 只读属性：动态计算出来的特征（比如仓库的满载率）
        public double fullRate
        {
            get { return (double)riceStock / 100; }// 假设仓库上限是100
        }
    }
    public class YuyukoBag
    {
        //使用字典存储数据
        private Dictionary<string,int> snackBag= new Dictionary<string,int>();

        // 声明索引器：让对象能像数组一样用 [] 访问
        public int? this[string snackname]
        {
            get
            {
                if(snackBag.ContainsKey(snackname))
                {
                    return snackBag[snackname];
                }


                else
                {
                    return null;
                }
            
            }

            set
            {
                // 设置点心数量时，值不能为空
                if (!value.HasValue)
                {
                    throw new Exception("这是异变！！");
                }
                // 如果字典里有这个点心就更新，没有就新增
                if ( snackBag.ContainsKey(snackname) )
                {
                    snackBag[snackname] = value.Value;
                } 
                else
                {
                    snackBag.Add(snackname, value.Value);
                }
            }

        }


    }

    public class GuestProfile
    {
        // 1. const 常量：编译时就能确定的值，属于类型，绝对不能改
        public const int MAX_FAVOURITYBILITY = 100;

        //2.静态只读字段：如果常量的类型是复杂的类或结构体，const 无法处理，就用 static readonly
        public static readonly string ServerAddress = "127.0.0.1:8080";
        // 3. 实例只读字段：只能在声明时或构造函数中赋值，一旦对象创建完成，终身不可变
        public readonly string BirthPlace;

        public GuestProfile(string palce) {
            // 只读字段可以在构造函数中被赋值
            BirthPlace = palce;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //IngredientWarehouse warehouse = new IngredientWarehouse();
            //warehouse.wareHouseName = "食材仓库";           
            //warehouse.RiceStock = 25;
            //Console.WriteLine($"{warehouse.wareHouseName}的满载率为{warehouse.fullRate}");

            //YuyukoBag yuyukoBag = new YuyukoBag();
            //yuyukoBag["月光团子"]=100;
            //yuyukoBag["饭团"] = 5;

            //Console.WriteLine($"幽幽子的月光团子还有{yuyukoBag["月光团子"]}个");
            //Console.WriteLine($"幽幽子的饭团还有{yuyukoBag["饭团"]}个");
            //Console.WriteLine($"幽幽子的大江户船祭还有{yuyukoBag["大江户船祭"]}个");

            //因为构造函数带参数，实例化的时候要带参数
            GuestProfile reimu = new GuestProfile("博丽神社");

            Console.WriteLine($"幻想乡好感度上限是{GuestProfile.MAX_FAVOURITYBILITY}");
            Console.WriteLine($"博丽灵梦的地点是{reimu.BirthPlace}");

        }
    }
}
