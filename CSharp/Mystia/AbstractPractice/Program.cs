using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractPractice
{
    abstract class BaseFairyStaff
    {
        protected string _name;
        protected decimal _baseSalary;

        protected BaseFairyStaff(string name,decimal baseSalary) 
        { 
            if (name == null || baseSalary <0)
                return;
            else
            {
                _name = name;
                _baseSalary = baseSalary;
            }
            
        }

        public abstract decimal CaculateSalry();
    }

    class LightFairy : BaseFairyStaff
    {
        public LightFairy (string name ,decimal baseSalary):base(name,baseSalary)
        {
            _name = name;
            _baseSalary = baseSalary;
        }
       
        public override decimal CaculateSalry()
        {
            return _baseSalary*=2.0m;
        }

        public void Salary()
        {
            Console.WriteLine($"{_name}的工资是{_baseSalary}");
        }
    }

    class IceFairy : BaseFairyStaff
    {
        public IceFairy(string name, decimal baseSalary) : base(name, baseSalary)
        {
            _name=name;
            _baseSalary=baseSalary;
        }

        public override decimal CaculateSalry()
        {
            return _baseSalary *= 3.0m;
        }
        public void Salary()
        {
            Console.WriteLine($"{_name}的工资是{_baseSalary}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var qilunuo = new IceFairy("琪露诺", 9.0m);
            qilunuo.Salary();
            var daYaoJing = new LightFairy("大妖精", 10.0m);
            daYaoJing.Salary();
        }
    }
}
