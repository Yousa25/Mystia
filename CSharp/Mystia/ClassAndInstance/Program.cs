using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;




namespace ClassAndInstance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //(new Form()).Text="My Form";
            //(new Form()).ShowDialog();

          

            Timer timer = new Timer();
            timer.Interval = 1*1000;
            timer.Elapsed += Timer_Elapsed; ;
            timer.Start();

            Console.ReadLine();


        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }

    }
}
