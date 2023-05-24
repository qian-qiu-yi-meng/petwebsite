using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeopetsApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisetrIndex()
        {
            return View();
        }
        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult SecurityCode()
        {
            string code = BLL.UserInfoBLL.GetValidateCode();
            return File(Common.CreateVerificationCodeImg.CreateValidateGraphic(code), "image/Jpeg");
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        public ActionResult UserLogin(string userName,string userPwd,string verifyCode)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userPwd) && !string.IsNullOrEmpty(verifyCode))
                {
                    string code = BLL.UserInfoBLL.SelectUserInfos(userName,userPwd,verifyCode);
                    return Content(code);
                }
                return Content("203");
            }
            catch (Exception)
            {
                return Content("404");
            }
        }
    }
}