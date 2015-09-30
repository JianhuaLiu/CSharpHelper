using CSharpHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                CSharpHelper项目，主要是针对于C#进行的封装操作方法。
                例如：Unix时间戳转换，Json序列化等
                后期会不断更新功能，并同时发布新版本。

                主体设计帮助类计划如下：
                1.CSharpHelper帮助类：针对C#工具方法进行封装操作。
                2.WebHelper帮助类：针对Web类库方法进行封装，并包含特效库。
                3.DataBaseHelper帮助类：针对多数据库进行调用方法。

                CSharpHelper帮助类结构如下：
                1.CSharpHelper：帮助类库
                2.CSharpConsole：调用控制台
            */

            //Console.WriteLine("时间帮助类测试开始 \n");
            //DateTime dt = DateTime.Now;
            //long l = dt.ToUnix();
            //Console.WriteLine("需要转换的DateTime为：" + dt);
            //Console.WriteLine("DateTime转换时间戳：{0}", l.ToString());
            //Console.WriteLine("时间戳转DateTime：{0}", l.ToDateTime());
            //Console.WriteLine("计算时间差：{0}", DateTimeHelper.DateDiffToString(dt, dt.AddDays(1)));
            //Console.WriteLine("计算时间差返回TimeSpan：{0}", DateTimeHelper.DateDiff(dt, dt.AddDays(1)));
            //Console.WriteLine(" \n 时间帮助类测试结束");

            //Console.WriteLine("测试序列化实体类");
            //BookModel bookMo = new BookModel { strBookName = "Name", strBookPass = "Pass", alBookReader = new List<string>() { "asdef" } };
            //bool result = SerializeHelper.Serialize<BookModel>(bookMo, SerializeType.BinaryFormatter, @"book.xml");
            //Console.WriteLine("BinaryFormatter序列化测试：" + result);
            //bookMo = SerializeHelper.DeSerialize<BookModel>(SerializeType.BinaryFormatter, @"book.xml");
            //Console.WriteLine("BinaryFormatter反序列化测试：" + bookMo.strBookName != "" ? "成功" : "失败");

            //BookModel2 bookMo2 = new BookModel2 { strBookName = "Name", strBookPass = "Pass" };
            //result = SerializeHelper.Serialize<BookModel2>(bookMo2, SerializeType.Soap, @"book.xml");
            //Console.WriteLine("Soap序列化测试：" + result);
            //bookMo2 = SerializeHelper.DeSerialize<BookModel2>(SerializeType.Soap, @"book.xml");
            //Console.WriteLine("Soap反序列化测试：" + bookMo.strBookName != "" ? "成功" : "失败");

            //result = SerializeHelper.Serialize<BookModel>(bookMo, SerializeType.Xml, @"book.xml");
            //Console.WriteLine("Xml序列化测试：" + result);
            //bookMo = SerializeHelper.DeSerialize<BookModel>(SerializeType.Xml, @"book.xml");
            //Console.WriteLine("Xml反序列化测试：" + bookMo.strBookName != "" ? "成功" : "失败");

            //List<BookModel> list = new List<BookModel> { bookMo };
            //DataSet ds = list.ToDataSet();
            //Console.WriteLine("List转DataSet：" + ds.Tables[0].Rows.Count);
            //list = ds.ToList<BookModel>();
            //Console.WriteLine("DataSet转List：" + list.Count);

            CookieHelper cookie = new CookieHelper("CookieName");
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            dicList.Add("111", "222");
            cookie.SetCookie(dicList);
            Console.WriteLine("Cookie测试：{0}", cookie.IsCreate);
            HttpCookie co = cookie.GetCookie();
            cookie.ClearCookie();
            Console.WriteLine("Cookie测试：{0}", cookie.IsCreate);

            Console.Read();
        }
    }
}
