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
            string oldcode = TempData["SecurityCode"] as string;
            string code = Common.CreateVerificationCodeImg.CreateRandomCode(4); //验证码的字符为4个
            TempData["SecurityCode"] = code; //验证码存放在TempData中
            return File(Common.CreateVerificationCodeImg.CreateValidateGraphic(code), "image/Jpeg");
        }
        public ActionResult UserLogin(string userName,string userPwd,string verifyCode)
        {
            if (!string.IsNullOrEmpty(userName)&&!string.IsNullOrEmpty(userName)&& !string.IsNullOrEmpty(userName))
            {
                if (BLL.UserInfoBLL.SelectUserInfos("18888288814", "123456"))
                {

                }
            }
            return Content("");
        }
    }
}