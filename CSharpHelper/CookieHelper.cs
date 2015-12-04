using System;
using System.Collections.Generic;
using System.Web;

namespace CSharpHelper
{
    /// <summary>
    /// Cookie帮助类
    /// </summary>
    public class CookieHelper
    {
        private string cookName = "";

        private CookieHelper()
        {
        }

        /// <summary>
        /// 定义Cookie名称
        /// </summary>
        /// <param name="name">Cookie名称</param>
        public CookieHelper(string name)
        {
            cookName = name;
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="Values">设置内容，键值对</param>
        /// <param name="Expires">过期时间，默认一天过期</param>
        public void SetCookie(Dictionary<string, string> Values, DateTime Expires = new DateTime())
        {
            HttpCookie Cookie = new HttpCookie(this.cookName);
            foreach (string key in Values.Keys)
            {
                Cookie.Values.Set(key, Values[key]);
            }
            Cookie.Expires = Expires == new DateTime() ? DateTime.Now.AddDays(1) : Expires;
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="Values">设置内容，键值对</param>
        /// <param name="Expires">过期时间，默认一天过期</param>
        public void SetCookie(string Values, DateTime Expires = new DateTime())
        {
            HttpCookie Cookie = new HttpCookie(this.cookName);
            Cookie.Value = Values;
            Cookie.Expires = Expires == new DateTime() ? DateTime.Now.AddDays(1) : Expires;
            HttpContext.Current.Response.Cookies.Add(Cookie);
        }

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <returns></returns>
        public HttpCookie GetCookie()
        {
            return HttpContext.Current.Request.Cookies[this.cookName];
        }

        /// <summary>
        /// 清空Cookie
        /// </summary>
        public void ClearCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[this.cookName];
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 是否已被创建
        /// </summary>
        public bool IsCreate
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[this.cookName];
                if (cookie != null)
                    return true;
                else
                    return false;
            }
        }
    }
}