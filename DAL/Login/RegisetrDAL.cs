using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RegisetrDAL
    {
		/// <summary>
		/// 用户注册
		/// </summary>
		/// <param name="userNmae">邮箱或电话号码</param>
		/// <param name="userPwd">密码</param>
		/// <param name="vCode">验证码</param>
		/// <returns></returns>
        public static string RegisetrUser(string userNmae,string userPwd,string vCode)
        {
			try
			{
				if (UserInfoDAL.list.Count>0)
				{
					var user = UserInfoDAL.list.Find(u => u.UserEmail == userNmae || u.UserPhone == userNmae);
					if (user != null)
					{
						return "202";
					}
					else
					{
						if (UserInfoDAL.vCode==vCode)
						{
                            InsertUser(userNmae, userPwd);
							UserInfoDAL.GetAllUserInfo();
							return "200";
                        }
						return "201";
                    }
				}
				return "203";
			}
			catch (Exception ex)
			{
				Common.LogHelper.Log.Error($"RegisetrUser error:{ex}");
				return "404";
			}
        }
		/// <summary>
		/// 执行SQL语句
		/// </summary>
		/// <param name="user">邮箱或电话号码</param>
		/// <param name="pwd">密码</param>
		/// <returns></returns>
		public static int InsertUser(string user,string pwd)
		{
			try
			{
                string email = user;
                string phone = "";
                if (user.Contains("@"))
                {
                    email = user;
                    phone = "";
                }
                else
                {
                    email = "";
                    phone = user;
                }
                var userNmae = Common.CreateVerificationCodeImg.CreateRandomCode(6);
                string str = $"insert into userinfo(username,useremail,phone,userpwd,userimg,usercreatetime,updateusertime) values('{userNmae}','{email}','{phone}','{pwd}','','{DateTime.Now}','{DateTime.Now}')";
                int sum = SqlHelper.ExecuteSql(str);
                return sum;
            }
			catch (Exception ex)
			{
				Common.LogHelper.Log.Error($"InsertUser error{ ex.Message}");
				return -1;
			}
            

        }
    }
}
