using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Ninesky.BLL;
using Ninesky.Common;
using Ninesky.IBLL;
using Ninesky.Models;
using Ninesky.Web.Areas.Member.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;

namespace Ninesky.Web.Areas.Member.Controllers
{
    public class UserController : Controller
    {
        #region 属性

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }

        #endregion 属性

        // GET: Member/User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            InterfaceUserService userService = new UserService();
            if (TempData["VerficationCode"] == null || TempData["VerficationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerficationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {
                if (userService.Exist(register.UserName)) ModelState.AddModelError("UserName", "用户名已存在");
                else
                {
                    User _user = new User()
                    {
                        UserName = register.UserName,
                        //默认用户组代码写这里
                        DisplayName = register.DisplayName,
                        Password = Security.Sha256(register.Password),
                        //邮箱验证与邮箱唯一性问题
                        Email = register.Email,
                        //用户状态问题
                        Status = 0,
                        LoginIP = "",
                        LoginTime = DateTime.Now,
                        RegistrationTime = DateTime.Now
                    };
                    _user = userService.Add(_user);
                    if (_user.UserID > 0)
                    {
                        var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignIn(_identity);
                        return RedirectToAction("Index", "Home");
                    }
                    else { ModelState.AddModelError("", "注册失败！"); }
                }
            }
            return View(register);
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home"); 
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            string verficationCode = Security.CreateVerificationText(6);
            Bitmap _img = Security.CreateVerification(verficationCode, 160, 30);
            _img.Save(Response.OutputStream, ImageFormat.Jpeg);
            TempData["VerficationCode"] = verficationCode.ToUpper();
            return null;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="returnURL">返回URL</param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            InterfaceUserService userService = new UserService();
            if (ModelState.IsValid)
            {
                var _user = userService.Find(loginViewModel.UserName);
                if (_user == null) ModelState.AddModelError("UserName", "用户名不存在");
                else if (_user.Password == Common.Security.Sha256(loginViewModel.Password))
                {
                    var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe }, _identity);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("Password", "密码错误");
            }
            return View();
        }
    }
}