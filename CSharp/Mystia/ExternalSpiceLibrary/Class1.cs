using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalSpiceLibrary
{
    public class SpiceLibrary
    {
        static string _name = "八角";
        public void GetSpiceName()
        {
            Console.WriteLine($"该香料的名字是{_name}");
        }
    }
}
