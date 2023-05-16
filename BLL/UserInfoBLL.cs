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
        public static bool SelectInfoBLL(string user,string pwd)
        {
            return DAL.UserInfoDAL.SelectUserInfo(user, pwd);
        }
        public static bool SelectUserInfos(string userName, string userPwd)
        {
            return DAL.UserInfoDAL.SelectUserInfo(userName,userPwd);
        }
    }
}
