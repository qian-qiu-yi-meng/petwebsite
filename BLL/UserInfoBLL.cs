using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfoBLL
    {
        public static string SelectInfoBLL(string user,string pwd,string code)
        {
            return DAL.UserInfoDAL.SelectUserInfo(user, pwd,code);
        }
        public static string SelectUserInfos(string userName, string userPwd,string code)
        {
            return DAL.UserInfoDAL.SelectUserInfo(userName,userPwd, code);
        }
        public static string GetValidateCode()
        {
            return DAL.UserInfoDAL.GetValidateCode();
        }
        public static bool GetAllUserInfo()
        {
            return DAL.UserInfoDAL.GetAllUserInfo();
        }
    }
}
