using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InterfaceAndAbstract
{
    //public abstract class BaseDish
    //{
    //     void PrepareIngredients()
    //    { 
    //    }

    //   public abstract void Cook();
    //}

    //class GriiledEel:BaseDish
    //{
    //    public override void Cook()
    //    {
    //        Console.WriteLine("正在烤八目鳗");
    //    }
    //}

    //class MisoSoup:BaseDish
    //{
    //    public override void Cook()
    //    {
    //        Console.WriteLine("正在煮味增汤");
    //    }
    //}


    interface Idelivery
    {
        void Deliver(string address);

    }

    abstract class OrderService 
    {
        private readonly Idelivery _delivery;
        protected OrderService( Idelivery idelivery) 
        {
            _delivery = idelivery;
        }
        public abstract void Deliver(string Name);



    }

    class ShrineDelivery:Idelivery
    {
       

        public  void Deliver(string address)
        {
            Console.WriteLine($"[神社配送员] 正在穿越博丽大结界，将外卖送往：{address}。记得带上赛钱！");
        }
    }

    class MansionDelivery : Idelivery
    {
        public  void Deliver(string address)
        {
            Console.WriteLine($"[洋馆配送员] 正在小心避开时间停止，将外卖送往红魔馆：{address}。请保持优雅！");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //BaseDish baseDish = new MisoSoup();
            //baseDish.Cook();
            //BaseDish baseDish1 = new GriiledEel();
            //baseDish1.Cook();
            MansionDelivery mansionDelivery = new MansionDelivery();
            Idelivery idelivery = new MansionDelivery();
            idelivery.Deliver("灵梦");

        }
    }
}
