using System.Web.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using GeekPeeked.Common.Models;
//using GeekPeeked.Common.Repositories;

namespace GeekPeeked.Web.Attributes
{
    public class ApiAuthenticationAttribute : System.Web.Http.AuthorizeAttribute
    {
        public ApiAuthenticationAttribute() : base()
        {
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.RequestContext.Principal != null &&
                actionContext.RequestContext.Principal.Identity != null &&
                actionContext.RequestContext.Principal.Identity.Name != null)
            {
                // TODO
                //var id = actionContext.RequestContext.Principal.Identity.Name;
                //var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
                //var user = Task.Run<ApplicationUser>(() => userRepository.Find(id)).Result;

                //if (user != null)
                //{
                //    if (user.LockoutEnabled == true)
                //    {
                //        HandleUnauthorizedRequest(actionContext);
                //        actionContext.Response.Headers.Add("X-AUTHFAILURECODE", "ACCOUNT_DISABLED");
                //    }

                //}
            }

            base.OnAuthorization(actionContext);
        }
    }
}