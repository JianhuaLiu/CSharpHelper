using System.Collections.Generic;
using System.Web;

namespace CSharpHelper
{
    /// <summary>
    /// Session帮助类
    /// </summary>
    public class SessionHelper
    {
        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="Values">设置内容，键值对</param>
        /// <param name="iExpires">调动有效期，时间分钟</param>
        public void SetSession(Dictionary<string, string> Values, int iExpires = 60)
        {
            foreach (string key in Values.Keys)
            {
                HttpContext.Current.Session[key] = Values[key];
            }
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="name">Session对象名称</param>
        /// <returns>Session对象内容</returns>
        public string GetSession(string name)
        {
            if (HttpContext.Current.Session[name] == null)
            {
                return "";
            }
            else
            {
                return HttpContext.Current.Session[name].ToString();
            }
        }

        /// <summary>
        /// 清空Cookie
        /// </summary>
        /// <param name="name">Session对象名称</param>
        public void ClearSession(string name)
        {
            HttpContext.Current.Session[name] = null;
        }

        /// <summary>
        /// 是否已经被创建Session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsCreate(string name)
        {
            if (HttpContext.Current.Session[name] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}