using System.Web.Mvc;

namespace GeekPeeked.Web.App_Start
{
    public class Authorization : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity == null)
                base.HandleUnauthorizedRequest(filterContext);
            else
                filterContext.Result = new RedirectResult("/Account/Unauthorized");
        }
    }
}