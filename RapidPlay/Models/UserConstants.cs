using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPlay.Models
{
    public class UserConstants
    {
        public static List<UserLogin> Users = new List<UserLogin>() {
           new UserLogin(){ Code="admin-root", Password="ad096bed1bc8ca" , }
        };
    }
}
