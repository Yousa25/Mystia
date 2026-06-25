using System;

namespace MystiaCabteen_Event
{
    //定义委托类型用于承载幽幽子饱食度事件
    public delegate void YuyukoHangryEventHandler(Yuyuko sender,YuyukoEventArgs e);

    public class YuyukoEventArgs:EventArgs
    {
        public int YuyukoHangry { get; set; }
        public string ExtraTag { get; set; }

    }
    public class Yuyuko
    {
        private int _hangry = 0;
        private string _extraTag = "水产";
        public int Hangry
        {
            get
            {
                return _hangry;
            }
            set
            { _hangry = value;
                //幽幽子饱食度发生变化时调用OnHangry方法
               this.OnHangry();
            }
        }

        //声明幽幽子的饱食度事件
        public event YuyukoHangryEventHandler hangryEventHandler;

        //定义hangry事件
        protected void OnHangry()
        {
            if (hangryEventHandler != null) 
            {
                YuyukoEventArgs yuyukoEventArgs = new YuyukoEventArgs();
                yuyukoEventArgs.YuyukoHangry = _hangry;
                switch(_hangry)
                {
                    case 20:
                        yuyukoEventArgs.ExtraTag = "高级";
                        hangryEventHandler.Invoke(this,yuyukoEventArgs);
                        break;
                    case 50:
                        yuyukoEventArgs.ExtraTag = "中华";
                        hangryEventHandler.Invoke(this, yuyukoEventArgs);
                        break;
                    case 70:
                        yuyukoEventArgs.ExtraTag = "和风";
                        hangryEventHandler.Invoke(this, yuyukoEventArgs);
                        break;
                }
                yuyukoEventArgs.ExtraTag = _extraTag;              
            }
        }

    }

    public class MystiaCanteen
    {
        string _currentTag = "小巧";
        public string CurrentTag { get; set; }
        public void YoyokoAction (Yuyuko yuyuko)
        {
            this.YuyukoWalkIn();
            this.YuyukoOrder();
            this.YuyukoEat();
            this.UpdateHangry(yuyuko);
            
        }

        //幽幽子进店
        public void YuyukoWalkIn()
        {
        }
        public void YuyukoOrder()
        {
        }
        public void YuyukoEat()
        {
            Console.WriteLine("幽幽子：还不错");
        }
        public void UpdateHangry(Yuyuko yuyuko)
        {
            yuyuko.Hangry += 5;
        }

        //饱食度变化事件处理器
        internal void UpdateExtraTag(Yuyuko sender, YuyukoEventArgs e)
        {
            CurrentTag =e.ExtraTag;
            Console.WriteLine($"幽幽子饱食度达到{e.YuyukoHangry}%,额外标签变更为{CurrentTag}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MystiaCanteen mystiaCanteen = new MystiaCanteen();
            Yuyuko yuyuko = new Yuyuko();
            //夜雀食堂关注着幽幽子的饱食度，当饱食度发生变化时，夜雀食堂的附加标签发生变化
            yuyuko.hangryEventHandler += mystiaCanteen.UpdateExtraTag;
            //模拟幽幽子反复吞食的案例
            for (int i = 0;i<20;i++)
            {
                mystiaCanteen.YoyokoAction(yuyuko);
            }
        }
    }
}
