using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WEBAPI
{
    public class AuthenticateUser: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization==null)
            {
                //IF credentials are not found in header section
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                //Create Authentication token if credentials are found
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                //decode the credential string
                string decoded = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                //Split the decoded string (usually the format will be username:password
                string[] credentials = decoded.Split(':');
                //Get UserName and Password Credebntials from decoded string
                string userName = credentials[0];
                string password = credentials[1];

                if(AuthenticateUsers.GetUsers(userName, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }

            }
        }
    }
}