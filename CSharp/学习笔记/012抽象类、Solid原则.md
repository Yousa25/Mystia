# 012抽象类、Solid原则.md

## SOLID原则

1. S - 单一职责原则 (Single Responsibility Principle, SRP)
核心概念：一个类应该只有一个引起它变化的原因。简单来说，就是一个类只负责一件事，不要把过多的功能塞进一个类里。
>夜雀食堂案例：米斯蒂娅不应该既负责“烤八目鳗”（料理制作），又负责“去人类村落收账”（财务管理），还要负责“和灵梦吵架”（公关维护）。应该把这些职责拆分成 Cook（厨师）、Accountant（会计）和 PublicRelations（公关）三个独立的类。
2. O - 开闭原则 (Open-Closed Principle, OCP)
核心概念：软件实体（类、模块、函数等）应该对扩展开放，对修改关闭。当需要添加新功能时，应该通过新增代码（扩展）来实现，而不是去修改已有的、已经测试通过的代码。
>夜雀食堂案例：夜雀食堂原本只卖“烤虫子”。现在要增加“烤蘑菇”。你不需要去修改原来的 BaseDish 抽象类或者主菜单的逻辑，只需要新写一个 GrilledMushroom 类去继承 BaseDish 即可。这就是对扩展开放（加新菜），对修改关闭（不改旧代码）。
3. L - 里氏替换原则 (Liskov Substitution Principle, LSP)
核心概念：子类对象必须能够替换掉所有父类对象。也就是说，子类继承父类时，不能改变父类原有的行为约定或抛出父类没有的异常。
>夜雀食堂案例：假设有一个基类叫 Bird（鸟），里面有个方法 Fly()（飞）。如果你写了一个子类 Penguin（企鹅）继承自 Bird，但企鹅不会飞，你在 Penguin 的 Fly() 方法里直接抛出异常或者什么都不做，这就违反了 LSP。因为如果主程序里有一行代码是 bird.Fly()，当传入的对象是企鹅时，程序就会崩溃。
4. I - 接口隔离原则 (Interface Segregation Principle, ISP)
核心概念：客户端不应该依赖它不需要的接口。一个类对另一个类的依赖应该建立在最小的接口上。不要试图用一个庞大的接口涵盖所有行为。
>夜雀食堂案例：你之前的笔记中提到的“坦克与汽车”就是绝佳的例子。在夜雀食堂里，不要定义一个巨大的 IEmployee（员工）接口，里面同时包含 Cook()（做饭）、CleanTable()（擦桌子）和 FightIntruder()（打退闯进来的勇者）。因为米斯蒂娅只需要做饭，擦桌子应该交给小妖精，打退勇者应该交给灵梦。把大接口拆分成 ICook、ICleaner 和 IFighter，让不同的角色只实现自己需要的接口。
5. D - 依赖倒置原则 (Dependency Inversion Principle, DIP)
核心概念：高层模块不应该依赖低层模块，两者都应该依赖其抽象；抽象不应该依赖细节，细节应该依赖抽象。这就是你笔记中提到的“依赖注入”和“反射”的核心思想。
>夜雀食堂案例：夜雀食堂的收银系统（高层模块）不应该直接 new 一个 ReimuHakurei（博丽灵梦）对象来收钱（低层模块）。因为如果灵梦今天去解决异变了，换成了魔理沙来收钱，你就得去改收银系统的代码。正确的做法是，收银系统只依赖一个抽象的 ICashier（收银员）接口。无论是灵梦还是魔理沙，只要实现了这个接口，都可以被注入到收银系统中。

## 抽象类

- 接口和抽象类都是“软件工程产物”
- 具体类->抽象类->接口：越来越抽象，内部实现的东西越来越少
- 抽象类是**未完全实现逻辑**的类（可以由字段和非public成员，它们代表了“具体逻辑”）
  - 一个类里的函数成员**至少有一个**abstract 修饰的成员，该类就是抽象类,必须要在class前也加上abstract关键字修饰

- 抽象类**为复用而生**(不能实例化抽象类)：专门**作为基类**来使用（父类声明引用子类的方式产生多态的效果），也具有解耦功能
- 封装确定的，开放不确定的，推迟到合适的**子类中去实现**
  - 方法被abstract修饰后，没有方法体：（又称为“纯虚方法”，虚方法还有方法体，子类可以重新实现方法而已，抽象方法是完全没有实现，必须要靠子类实现才行）
``` c#
abstract class Student
{
    abstract public void Study();
}

```

``` c#
class Car{
  public void Run(){
    Console.WriteLine("Car is running...");

  }

  public void Stop()
  {
    Console.WriteLine("Stopped");
  }
}


class Truck{
  public void Run(){
    Console.WriteLine("Car is running...");

  }

  public void Stop()
  {
    Console.WriteLine("Stopped");
  }
}
```
 违法设计原则：不可以复制粘贴，可以用基类派生而来，基类用虚方法替代复制粘贴操作，实例化时用多态去实例化父类下的子类即可。
 ``` c#
using System;

namespace Example027
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Stop();
        }

        class Vehicle
        {
            public void Stop()
            {
                Console.WriteLine("Stopped!");
            }
        }
        class Car:Vehicle
        {
            public void Run()
            {
                Console.WriteLine("Car is Running");
            }


        }

        class Truck:Vehicle
        {
            public void Run()
            {
                Console.WriteLine("Car is Running");
            }
        }
    }
}

```
此时用多态去实例化Car类，只能实例化到Stop,因为用vehicle的引用变量，里面只有函数成员Stop，没有Run，为了可以引用Run()的成员函数，可以在父类里用virtual,虚方法写一个Run，让其子类加上override重写。就可以引用了。

``` c#
using System;

namespace Example027
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Run();
        }

        class Vehicle
        {
            public void Stop()
            {
                Console.WriteLine("Stopped!");
            }

            public virtual void Run()
            {

            }
        }
        class Car:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }


        }

        class Truck:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }
        }
    }
}


```

 基类中的方法不需要，它只是为了让子类重写的方法而已，所以把方法体去掉。加上abstract，该方法成了抽象方法，该方法所在的类成为了抽象类。
 此时Vehicle类中的Run()方法没有实际的作用，完全是为了让子类实现而产生的，根本不需要方法体，所以可以在该方法里加上abstract关键字让它成为抽象方法，在该类也加上abstract关键字，让该类成为抽象类。
``` c#
using System;

namespace Example027
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.Run();
        }

       abstract class Vehicle
        {
            public void Stop()
            {
                Console.WriteLine("Stopped!");
            }

            public abstract void Run();
     
        }
        class Car:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }


        }

        class Truck:Vehicle
        {
            public override void Run()
            {
                Console.WriteLine("Car is Running");
            }
        }
    }
}


```
 此时如果想添加相关类，只需要继承该基类并且**必须实现**其中的抽象成员，如果不实现抽象成员，会报错，除非该类也添加abstract关键字成为抽象类。因为抽象类的方法体没有实现，所以不能实例化抽象类，但可以利用多态将抽象类作为引用变量实例化其具体的子类。



