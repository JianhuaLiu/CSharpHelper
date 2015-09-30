using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHelper
{
    [Serializable] //类可以序列化
    public class BookModel
    {
        //测试数组
        public List<string> alBookReader;
        public BookModel()
        {
            alBookReader = new List<string> { "asdf", "fdsa" };
        }

        //测试字段
        public string strBookName;

        //测试不进行实例化
        [NonSerialized]
        public string strBookPass;

        private string _bookId;
        //测试属性
        public string BookId { get; set; }
    }

    [Serializable] //类可以序列化
    public class BookModel2
    {
        //测试数组
        [NonSerialized]
        public List<string> alBookReader;

        //测试字段
        public string strBookName;

        //测试不进行实例化
        [NonSerialized]
        public string strBookPass;

        private string _bookId;
        //测试属性
        public string BookId { get; set; }
    }
}
