using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WEBAPI
{
    public class RequireHttpsFromHttp: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Found);
                UriBuilder builder = new UriBuilder(actionContext.Request.RequestUri);
                builder.Scheme = Uri.UriSchemeHttps;
                builder.Port = 44300;
               actionContext.Response.Headers.Location = builder.Uri;
            }
            else
            {
                base.OnAuthorization(actionContext);
            }
        }
    }
}