using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Event
{
    //点菜事件：只有自己的业务才有的逻辑，所以需要自定义事件
    //Order事件基于委托类型，注意是是声明委托类型还是声明委托类型字段

    //完整声明

    //使用EventHandler后缀的用意：
    //1.知道该委托是用来声明事件
    //2.用来约束事件处理器 
    //3.该实例创建出来是用于事件处理器
    //4.增强可读性

    /// <summary>
    /// 该委托类型是为了声明Order事件
    /// </summary>
    /// <param name="serder">谁点的菜</param>
    /// <param name="e">菜的样式</param>
    public delegate void OrderEventHandler(Customer customer,OrderEventArgs e);

    //用来传递消息的类
    //使用EventArgs同理，约定俗成要写成派生于EventArgs类
    public class OrderEventArgs:EventArgs
    {

        public string DishName { get; set; }
        public string Size { get; set; }
    }


    // 事件拥有者 Customer类
    public class Customer
    {
        public double Bill { get; set; }
        //声明order事件处理器 不想被外界访问，所以用private修饰,用于存储或者引用事件处理器
        #region 事件完整声明
        //private OrderEventHandler orderEventHandler;
        ////完整声明 order事件 要用委托类型OrderEventHandler约束该order事件
        //public event OrderEventHandler Order
        //{
        //    // 事件处理添加器add
        //    add
        //    {
        //        orderEventHandler += value;
        //    }
        //    //事件处理移除器
        //    remove
        //    {
        //        orderEventHandler -= value;
        //    }
        //}
        #endregion
        // 简化声明 
        // 这样很像一个字段
        public event OrderEventHandler Order;
        public void PayTheBill()
        {
            Console.WriteLine($"I will pay ${this.Bill}");
        }

        public void WalkIn()
        {
            Console.WriteLine("客人进店");
        }
        public void SitDown()
        {
            Console.WriteLine("客人坐下");
        }
        public void Think()
        {
            Console.WriteLine("客人思考");
            Thread.Sleep(5000);


        }

        protected void OnOrder(string dishName , string size)
        {
            //if这里用的是委托进行判断，不可以使用事件order，事件只能用在+=或-=操作符
            if (Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                //事件必须由事件拥有者触发，所以第一个参数为this
                Order.Invoke(this, e);
            }
        }

        public void action(string dishName,string size)
        {
            this.WalkIn();
            this.SitDown();
            this.Think();
            this.OnOrder(dishName,size);
            this.PayTheBill();
        }
 
    }

    //事件响应者 waiter
    public class Waiter
    {
        internal void Action(Customer customer, OrderEventArgs e)
        {
            //处理order事件
            Console.WriteLine($"请随便下单,你要点的是{e.DishName}");
            double price = 10;

            switch (e.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }

            customer.Bill += price;
        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            //事件拥有者
            Customer customer = new Customer();
            //事件响应者
            Waiter waiter = new Waiter();
            //事件：order 事件处理器:action,事件的订阅+= 
            //用委托实例存储事件处理器 action
            //使用简化声明时可以这样使用：customer.Order = new OrderEventHandler(waiter.Action);
            customer.Order += waiter.Action;
            customer.action("烤八目鳗","large");
           
            
        }


    }
}
