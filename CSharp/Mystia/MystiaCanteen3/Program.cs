using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MystiaCanteen3
{
    public class FoodItem
    {
        string _name = "";
        decimal _price = 1.0M;
        static int _totalFoodCount = 10;
        public string Name { get; set; }
        protected decimal Price { get; }

        protected FoodItem(string name)
        {
            this.Name = name;
            _totalFoodCount++;
        }

        ~ FoodItem() { 
            _totalFoodCount--;
            Console.WriteLine($"一份美味的{this.Name}消失了");
        }
    }

    class Ingredient : FoodItem
    {
        string _freshness;

        public string Freshness { get; set; }

        protected Ingredient(string name,string freshness):base (name) 
        {         
            Freshness = freshness;
        }

        //static void Main(string[] args)
        //{
        //    Ingredient ingredient = new Ingredient("八目鳗", "新鲜");
        //}
    }


    public class Guest
    {
        public double _secretBudget;
        public string Name { get; set; }
        internal string GuestFavourite { get; set; }


        public virtual void Order()
        {
            Console.WriteLine($"{Name}正在看菜单");
        }
    }

    public class XiGuest:Guest
    {
        public XiGuest()
        {
            this._secretBudget = 0;
        }

        protected void UseSpellCard()
        {
            Console.WriteLine($"{Name}使用了符卡");
        }
    }

    public class YoukaiGuest:Guest
    {
        public override void Order()
        {
            Console.WriteLine($"{Name}正在小心翼翼的看菜单");
        }
    }

    sealed class HignFavourityGuest:XiGuest
    {

    }




    public class Song
    {
        public string  SongName { get; set; }
        public virtual void Perform(Guest guest)
        {
            Console.WriteLine($"米斯蒂娅开始演唱{SongName}，扣除米斯蒂娅体力10");
        }
    }

    internal class Lullaby:Song
    {
        public override void Perform(Guest guest)
        {
            base.Perform(guest);
            Console.WriteLine($"{guest.Name}感到困倦，点单速度变慢了...");
        }
    }

    internal class UpbeatSong:Song
    {
        public override void Perform(Guest guest)
        {
            base.Perform(guest);
            Console.WriteLine($"气氛热烈！{guest.Name}的食欲增加了！");
        }
    }


    public class Program
    {
        public static void  Main()
        {
            List<Song> list = new List<Song>();
            list.Add(new Lullaby());
            list.Add(new UpbeatSong());
            list.Add(new Lullaby());
            list.Add(new UpbeatSong());
            list.Add(new Lullaby());
            list.Add(new UpbeatSong());

            Guest guest = new HignFavourityGuest();
            guest.Name = "琪露诺";

            foreach (Song song in list)
            {
                song.Perform(guest);
            }
        }
    }
}
