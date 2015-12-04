using System;

namespace MethodView
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////自定义排序功能
            //SortedSetList list = new SortedSetList();

            ////重写操作符
            //OperatorDemo demo1 = new OperatorDemo(1);
            //OperatorDemo demo2 = new OperatorDemo(2);
            //Console.WriteLine(demo1 + demo2);

            ////C#6.0新特性
            //CSharp6 cs = new CSharp6();

            //委托测试
            DelegateDemo del = new DelegateDemo();
            Console.ReadLine();
        }
    }
}