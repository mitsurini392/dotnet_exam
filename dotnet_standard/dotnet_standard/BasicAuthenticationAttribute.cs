using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace dotnet_standard
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext) {
            if (actionContext.Request.Headers.Authorization == null) {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] emailAddPasswordArr = decodedAuthToken.Split(':');
                string emailAdd = emailAddPasswordArr[0];
                string password = emailAddPasswordArr[1];

                if (MovieRentalSecurity.Login(emailAdd, password)) {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(emailAdd), null);
                }
                else {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}