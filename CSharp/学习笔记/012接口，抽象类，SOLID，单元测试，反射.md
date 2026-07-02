




## 接口与单元测试
- 当某一个抽象类的成员都是抽象方法，那么这个抽象类就是接口：将public abstract 替换为interface即可。由于接口内部所有的抽象方法都默认为public，所以在接口内部不写public.和abstract，又因为没有了abstract关键字，所以在实现接口的时候，也不可以写override关键字。接口名称用I开头。
``` c#
abstract class Student
{
    abstract public void Study();
}



interface IStudent()
{
  void Study();
}
```

- 接口
  - ![alt text](image-82.png)
  - 接口是**完全未实现**逻辑的“类”（“纯虚类”；只有函数成员；成员全部public）
  - 接口为解耦而生：“高内聚，低耦合”，方便单元测试
  - 接口是一个“协约”，早已为工业生产所熟知（有分工必有协作，有协作必有协约）
  - 接口和抽象类都不能实例化，只能用来声明变量、引用具体类（concrete class）的实例
- 接口与单元测试
  - 接口的缠上：自底向上（重构），自顶向下（设计）
  - C#中接口的实现（隐式，显式，多借口）
  - 语言对面向对象设计的内建支持：依赖反转，接口隔离，开/闭原则……


![alt text](image-83.png)
![alt text](image-84.png)

依赖反转：当有多个一个类依赖另一个类紧时，在他们之中找到更抽象的类成为接口，让这多个类实现这个接口，依赖关系从一对一到多对一。并且让这些类依赖于更抽象的接口。依赖关系从往下变上。
当类实现一个接口的时候，类与接口之间的关系也式紧耦合。
![alt text](image-85.png)
![alt text](image-86.png)

## 单元测试：添加对应项目的测试项目。推荐xUnit.
项目名称为：项目名称.Tests
![alt text](image-87.png)
- 先引入要测试的项目。

``` c#

[Fact]
public void PowerLowerThanZero_OK()
{
  var fan = new DeskFan(new PowerSupplyLowerThanZero());
  var expected = "Won't work";
  var actual = fan.Work();
  Assert.Equal(expected,actual);
}

class PowerSupplyLowerThanZero:IPowerSupply
{
  public int GetPower()
  {
    return 0;
  }
}
```

![alt text](image-88.png)
左侧的测试图标颜色变绿，为通过，变红则不通过。

Moq测试:mock测试简化单元测试，不用创建很多的类。
右键点击项目->Nuget->"Moq"->安装
使用方法：

``` c#
using moq;
var mock = new Mock<IPowerSupply>();
mock.Setup(ps=>ps.GetPower()).Returns(()=>0);  
var fan = new DeskFan(new PowerSupplyLowerThanZero(mock.Object));
```
 ## 单一原则
一个接口只实现一个或者一类功能，比如坦克类与汽车类。汽车类中有驾驶的方法。坦克有武器系统。想要给他们合成一个接口需要将坦克分为武器和开火两个接口。

坦克继承武器和驾驶两个接口。
汽车只继承驾驶这个接口。

## 接口的显式实现

- 一个类可以实现多个接口，但有的时候，部分接口不想让人轻易调用，这个时候就需要显式接口实现，将需要让人调用的接口显式实现。
- ![alt text](image-89.png)
  - Implement interface：隐式实现
  - Implement interface explicity
  - void 要实现的接口名.要实现的接口方法（）{}，也就意味着，只有用该接口的类型才可以调用这个方法，就实现了接口隔离。
  - ![alt text](image-90.png)，此时调用不到隐式实现的接口方法，可以进行类型转换来调用。

## 反射

- 反射与依赖注入
  - 反射：以不变应万变（更松的耦合）
  - 反射与接口的结合
  - 反射与特性的结合
- 用法：
  - 命名空间System.Reflection;
  - Type t =tank.GetType();
  - Activator:激活器类 Activator.CreateInstance(t);
  - 在知道这个类里的方法的狮虎可以这月调用，假设我知道里面有方法run()和fire
  - MethodInfo fireMi=t.GetMethod("Fire");
  - MethodInfo runMi=t.GetMethod("Run");
  - fireMi.Invoke(p,null);放入两个参数：第一个：要反射的对象，第二个：如果方法需要参数以数组的方式传入，如果没有传null。

## 封装好的反射--依赖注入
- 依赖注入框架
  - Nuget:Microsoft.Extensions.DependencyInjection
- 使用方法
  - using Microsoft.Extensions.DependencyInjection
  - var sc = new ServiceColletion();
  - sc.AddScoped(typeoe(ITank),typeof(HeavyTank));第一个参数：接口类型，第二个参数：哪个类实现的这个接口。注意不能之间把Itank放进去，因为ITank是个静态类型，需要用typeof（）将它转化为动态。
  - var sp = sc.BuildServiceProvider();
  - //以上在进行注册操作，ServiceColletion实际上是个容器。以后想使用这个接口时，不用new一个对象。可以在程序的任何地方进行调用。
  - ITank tank = sp.GetService<ITank>();
  - tank.Fire();
  - tank.Run();
  - 假如在项目升级时，需要将heavyTank换其他的，只需要改这一个地方，而不必在每个new HeavyTank();的地方去改。
  - ![alt text](image-91.png)
  - 依赖注入实际上是注入到类的构造器中，内存中生成一个实例，在程序的任何地方都可以使用

## 反射--松耦合--插件式编程
插件：不与主体程序一起编译但是可以与主体程序一起工作的组件。比如MOD，且反射可以批量注入实例，而不需要为每一个进行实例化。

案例-婴儿车小程序：利用IO从项目文件夹中找到是否有某个文件，该文件是否有对应的method，如果有进行依赖注入。模拟SDK接受第三方修改。
第一方：
![alt text](image-92.png)
![alt text](image-94.png)

为帮助第三方不必要错误，第一方发布SDK需要准备：

- IAnimal 接口：
  - 所有的厂商都要实现这个IAniaml接口。
- 如果有没开发完的，要进行过滤：继承Arribute基类

![alt text](image-97.png)
![alt text](image-98.png)
![alt text](image-99.png)

发布SDK：
写配置说明书


第三方使用SDK：
![alt text](image-100.png)
没开发完的用特性标记：
![alt text](image-101.png)

主体文件更新第三方的dll
![alt text](image-105.png)
![alt text](image-104.png)