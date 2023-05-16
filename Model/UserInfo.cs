using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserPwd { get; set; }
        public string UserImg { get; set; }
        public DateTime UserCreateTime { get; set; }
        public DateTime UpdateUserTime { get; set; }
    }
}
