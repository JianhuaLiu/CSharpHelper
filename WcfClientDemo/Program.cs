using System;
using WcfClientDemo.WcfService;

namespace WcfClientDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            UserClient service = new UserClient();
            Console.WriteLine(service.ShowName("晨星宇"));
            Console.ReadLine();
        }
    }
}