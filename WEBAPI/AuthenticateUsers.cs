using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbContext;
namespace WEBAPI
{
    public class AuthenticateUsers
    {
        public static bool GetUsers(string userName,string password)
        {
            using (vinudbContext context = new vinudbContext())
            {
                return context.Authorizes.Any(x => x.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) && x.Password == password);
            }
        }
    }
}