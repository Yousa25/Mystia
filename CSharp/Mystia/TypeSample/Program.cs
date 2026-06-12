using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type maType = typeof(Form);
            PropertyInfo[] properties = maType.GetProperties();
            MethodInfo[] methodInfos = maType.GetMethods();
            EventInfo[] eventInfos = maType.GetEvents();
            
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }
            foreach (MethodInfo method in methodInfos)
            {
                Console.WriteLine(method.Name);
            }

        }
    }
}
