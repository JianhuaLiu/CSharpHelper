using System;

namespace CSharpConsole
{
    internal class Program
    {
        private static void Main(string[] args)
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

            //CookieHelper cookie = new CookieHelper("CookieName");
            //Dictionary<string, string> dicList = new Dictionary<string, string>();
            //dicList.Add("111", "222");
            //cookie.SetCookie(dicList);
            //Console.WriteLine("Cookie测试：{0}", cookie.IsCreate);
            //HttpCookie co = cookie.GetCookie();
            //cookie.ClearCookie();
            //Console.WriteLine("Cookie测试：{0}", cookie.IsCreate);
            //LogHelper.ErrorWriteLog("123");

            //var sutl = @"https://www.baidu.com/index.php?tn=monline_3_dg".Response();
            //BookModel mo = null;
            //var data = new
            //{
            //    answer = "202CB962AC59075B964B07152D234B70",
            //    appid = 4,
            //    batchId = "",
            //    callbackFun = "shine3",
            //    format = "jsonp",
            //    g_tk = "1554830967",
            //    hostUin = "931607861",
            //    idcNum = 0,
            //    inCharset = "utf-8",
            //    json_esc = 1,
            //    mode = 0,
            //    noTopic = 0,
            //    notice = 0,
            //    outCharset = "utf-8",
            //    outstyle = "json",
            //    pageNum = 1,
            //    pageStart = 0,
            //    plat = "qzone",
            //    question = "米西米西滑不拉几",
            //    singleurl = 1,
            //    skipCmtCount = 0,
            //    source = "qzone",
            //    t = "691129497",
            //    topicId = "V138QnR81i9jnr",
            //    uin = "931607861"
            //};

            //for (int i = 0; i < 10; i++)
            //{
            //    string result = MemoryCacheHelper.GetCache<string>("access", delegate ()
            //    {
            //        return "fdsa";
            //    }, new TimeSpan(1, 50, 50));
            //    Console.Read();
            //}

            //string str1 = "QQ号1025395601";
            //Console.WriteLine("MD5:" + str1.MD5());
            //Console.WriteLine("SHA1:" + str1.SHA1());
            //Console.WriteLine("SHA256:" + str1.SHA256());
            //Console.WriteLine("SHA384:" + str1.SHA384());
            //Console.WriteLine("SHA512:" + str1.SHA512());
            //Console.WriteLine();

            //Console.WriteLine("DES对称加密");
            //byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //string enstr1 = str1.EnDES(iv, key);
            //Console.WriteLine("DES加密：" + enstr1);
            //Console.WriteLine("DES解密：" + enstr1.DeDES(key, iv));
            //Console.WriteLine();

            //byte[] key2 = CreateKey(24);
            //string enstr2 = str1.EnTripleDES(key2, iv);
            //Console.WriteLine("TripleDES加密：" + enstr2);
            //Console.WriteLine("TripleDES解密：" + enstr2.DeTripleDES(key2, iv));
            //Console.WriteLine();

            //byte[] key3 = CreateKey(32);
            //byte[] iv2 = CreateKey(16);
            //string enstr3 = str1.EnAES(key3, iv2);
            //Console.WriteLine("AES加密：" + enstr3);
            //Console.WriteLine("AES解密：" + enstr3.DeAES(key3, iv2));
            //Console.WriteLine();

            //string enstr4 = str1.EnRijndael(key3, iv2);
            //Console.WriteLine("Rijndael加密：" + enstr4);
            //Console.WriteLine("Rijndael解密：" + enstr4.DeRijndael(key3, iv2));
            //Console.WriteLine();

            //RSA rsa = RSA.Create();
            //string enstr5 = str1.EnRSA(rsa.ToXmlString(false));
            //Console.WriteLine("RSA加密："+enstr5);
            //Console.WriteLine("RSA解密："+enstr5.DeRSA(rsa.ToXmlString(true)));
            //Console.WriteLine();
            ////http://blog.csdn.net/ghostbear/article/details/7333477
            //DSA dsa = DSA.Create();
            //byte[] str2 = CreateKey(8);
            //string enstr6 = "12345678".EnDSA(dsa.ToXmlString(true));
            //Console.WriteLine("DSA加密：" + enstr6);
            //Console.WriteLine("DSA解密：" + enstr6.DeDSA(dsa.ToXmlString(false), "12345678"));
            //Console.WriteLine();

            Console.Read();
        }

        //static byte[] CreateKey(int num)
        //{
        //    byte[] result = new byte[num];
        //    Random rand = new Random();
        //    for (int i = 0; i < num; i++)
        //    {
        //        result[i] = (Byte)rand.Next(1, 256);
        //    }
        //    return result;

        //}
    }
}