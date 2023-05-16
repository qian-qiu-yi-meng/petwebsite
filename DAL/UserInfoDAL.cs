using Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="userName">用户邮箱或电话号码</param>
        /// <param name="userPwd">密码</param>
        /// <returns></returns>
        public static bool SelectUserInfo(string userName,string userPwd)
        {
            //var md5 = Common.MD5Helper.GetMD5Hash("1111111");
            //var md51 = Common.MD5Helper.VerifyMD5Hash("1111111", "7FA8282AD93047A4D6FE6111C93B308A");
            // 按条件进行查询
            string str = "select * from userinfo where (useremail=@userName or phone=@userName) and userpwd=@userPwd";
            // 查询所有数据
            //string str = "select * from userinfo";
            MySqlParameter[] pars =
            {
                new MySqlParameter(@"UserName",MySqlDbType.VarChar,50),
                new MySqlParameter(@"UserPwd",MySqlDbType.VarChar,50),
            };
            pars[0].Value = userName;
            pars[1].Value = userPwd;
            DataTable da= SqlHelper.GetTable(str, CommandType.Text, pars);
            
            UserInfo userInfo = null;
            if (da.Rows.Count>0)
            {
                userInfo = new UserInfo();
                LoadEntity(userInfo, da.Rows[0]);
            }
            return true;
        }
        public static void LoadEntity(UserInfo userInfo,DataRow row)
        {
            userInfo.UserId = Convert.ToInt32(row["UserId"]);
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.UserPwd = row["UserPwd"] != DBNull.Value ? row["UserPwd"].ToString() : string.Empty;
            userInfo.UserEmail = row["UserEmail"] != DBNull.Value ? row["UserEmail"].ToString() : string.Empty;
            userInfo.UserImg = row["UserImg"] != DBNull.Value ? row["UserImg"].ToString() : string.Empty;
            userInfo.UserCreateTime = Convert.ToDateTime(row["UserCreateTime"]);
            userInfo.UpdateUserTime = Convert.ToDateTime(row["UpdateUserTime"]);
        }

        public static void SelectAllUserInfo(DataRowCollection data)
        {
            List<UserInfo> user = new List<UserInfo>();
            for (int i = 0; i < data.Count; i++)
            {
                UserInfo info = new UserInfo();
                LoadEntity(info, data[i]);
                user.Add(info);
            }
        }
    }
}
