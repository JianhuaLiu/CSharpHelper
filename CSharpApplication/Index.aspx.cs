using CSharpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSharpApplication
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CookieHelper help = new CookieHelper("CookieName");
            //Dictionary<string, string> di = new Dictionary<string, string>();
            //di.Add("Name", "晨星宇");
            //help.SetCookie("晨星宇");
            //var result=  help.GetCookie();
            //var a = help.IsCreate;

            SessionHelper help = new SessionHelper();
            Dictionary<string, string> di = new Dictionary<string, string>();
            di.Add("Name","晨星宇");
            help.SetSession(di);
            var result = help.GetSession("Name");
        }
    }
}