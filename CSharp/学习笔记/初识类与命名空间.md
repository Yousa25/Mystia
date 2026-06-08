# C#学习--来自于刘铁猛老师的C#教程
 
 ## 1.初识类（class）与命名空间（namespace）

### 1.1 hello，world程序

- 类（class）构成程序的主体
- 名称空间（namespace）以树形结构组织类（和其他类型）
  - 例如Button和Path类

``` CSharp
using System;

namespace Mystia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("欢迎来到夜雀食堂");
            
        }
    }
}

```            
命名空间与类：

在这里可以看到 Program和Console都属于类，其中Program是自己写的类。Console类是属于System命名空间，如果不加上using System;会使Console类找不到而失效。
（生成案例）


#### Q&A

1. 如何知道使用的类来自于哪个命名空间？
   1. 从MSDN文档里查看
   2. 在需要看到的下面查看智能标记可以看来源的命名空间。
   
2. 可不可以将所有的命名空间引用进来？
   1. 不可以。
   2. 比如Path类，在System.Windows.shapes.Path中有，是用来多边形的。在System.IO.Path中也有，这是控制文件路径的类。
   3. 比如Buton类，在很多的程序里都有button类，系统会分不清要用的是哪种button。

### 1.2 类库的引用
- 类库引用是使用名称空间的物理基础
  ![alt text](image.png)
  - 不同技术类型的项目会默认引用不同的类库
    比如winform程序的模板实际上是引用了winform相关的类库：System.Windows.Forms 。并且也可以自己添加类库，比如在控制台程序引用System.Windows.Forms就可以在控制台中实现窗口内容。
    （生成案例）

``` csharp
using System.Windows.Forms;

namespace Mystia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.ShowDialog();
        }
    }
}
```
- DLL引用（黑盒引用，无源代码）
  - Nuget简介
    - 用来解决复杂的依赖关系：底层的库没有引用，直接使用上层的库是不可以的，某一个库可能含有多层底库，可以使用Nuget技术将所需要的库全部打包引入，避免遗漏。
  - 使用DLL的时候一定要配有文档：文档中要写如下内容：
    - 命名空间
    - 命名空间包含的类
    - 类中包含的方法
    - 方法的说明
  - 黑盒引用的问题
    - 黑盒中类库的代码出现问题，无法更改其中的代码。
    （生成案例）
- 项目引用（白盒引用，有源代码）步骤
  - 1. 用一个项目包含另一个项目（另一个项目是类库项目）
  - 2. 自建一个类库项目：Class library
  （生成案例）
### 1.3 依赖关系

- 类（或对象）之间的耦合关系，高内聚低耦合。
  
### 1.4 自学案例：
- 创建类库项目进行项目引用
- 练习DLL引用