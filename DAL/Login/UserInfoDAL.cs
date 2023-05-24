using Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DAL
{
    public class UserInfoDAL
    {
        // 存储验证码
        public static string vCode;
        // 存储数据库用户信息
        public static List<UserInfo> list;
        /// <summary>
        /// 查询用户是否存在
        /// </summary>
        /// <param name="userName">用户邮箱或电话号码</param>
        /// <param name="userPwd">密码</param>
        /// <param name="verifyCode">验证码</param>
        /// <returns></returns>
        public static string SelectUserInfo(string userName,string userPwd,string verifyCode)
        {
            try
            {
                if (list.Count > 0)
                {
                    var user = list.Find(u => u.UserPhone == userName || u.UserEmail == userName && u.UserPwd == userPwd);
                    if (user != null)
                    {
                        if (vCode == verifyCode)
                        {
                            return "200";
                        }
                        return "201";
                    }
                }
                return "202";
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error($"SelectUserInfo error:{ex}");
                return "404";
            }

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
            //try
            //{
            //    //var md5 = Common.MD5Helper.GetMD5Hash("1111111");
            //    //var md51 = Common.MD5Helper.VerifyMD5Hash("1111111", "7FA8282AD93047A4D6FE6111C93B308A");
            //    // 按条件进行查询
            //    string str = "select * from userinfo where (useremail=@userName or phone=@userName) and userpwd=@userPwd";
            //    // 查询所有数据
            //    //string str = "select * from userinfo";
            //    MySqlParameter[] pars =
            //    {
            //    new MySqlParameter(@"UserName",MySqlDbType.VarChar,50),
            //    new MySqlParameter(@"UserPwd",MySqlDbType.VarChar,50),
            //};
            //    pars[0].Value = userName;
            //    pars[1].Value = userPwd;
            //    DataTable da = SqlHelper.GetTable(str, CommandType.Text, pars);

            //    UserInfo userInfo = null;
            //    if (da.Rows.Count > 0)
            //    {
            //        userInfo = new UserInfo();
            //        LoadEntity(userInfo, da.Rows[0]);
            //    }
            //    else
            //    {
            //        return "202";
            //    }
            //    if (verifyCode == vCode)
            //    {
            //        LogHelper.Log.Info("登录成功");
            //        return "200";
            //    }
            //    return "201";
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.Log.Error(ex);
            //    return "404";
            //}
            //List<UserInfo> user = new List<UserInfo>();
            //for (int i = 0; i < data.Count; i++)
            //{
            //    UserInfo info = new UserInfo();
            //    LoadEntity(info, data[i]);
            //    user.Add(info);
            //}
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public static string GetValidateCode()
        {
            try
            {
                string code = Common.CreateVerificationCodeImg.CreateRandomCode(4); //验证码的字符为4个
                vCode = code;
                return code;
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error($"GetValidateCode error:{ex}");
                return null;
            }
            
        }
        /// <summary>
        /// 查询所有用户数据并存储到临时数据中
        /// </summary>
        public static bool GetAllUserInfo()
        {
            try
            {
                list = new List<UserInfo>();
                string sqlstr = "select * from userinfo";
                var user = SqlHelper.SelectAllDate(sqlstr);
                if (user.Rows.Count > 0)
                {
                    foreach (DataRow row in user.Rows)
                    {
                        list.Add(new UserInfo()
                        {
                            UserId = Convert.ToInt32(row["UserId"]),
                            UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty,
                            UserPwd = row["UserPwd"] != DBNull.Value ? row["UserPwd"].ToString() : string.Empty,
                            UserEmail = row["UserEmail"] != DBNull.Value ? row["UserEmail"].ToString() : string.Empty,
                            UserImg = row["UserImg"] != DBNull.Value ? row["UserImg"].ToString() : string.Empty,
                            UserPhone = row["Phone"] != DBNull.Value ? row["Phone"].ToString() : string.Empty,
                            UserCreateTime = Convert.ToDateTime(row["UserCreateTime"]),
                            UpdateUserTime = Convert.ToDateTime(row["UpdateUserTime"]),
                        });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error($"GetAllUserInfo error:{ex}");
                return false;
            }
            
            
        }

    }
}
