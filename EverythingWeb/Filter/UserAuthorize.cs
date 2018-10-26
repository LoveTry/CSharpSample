using EverythingWeb.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb.Filter
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            base.AuthorizeCore(httpContext);
            if (HttpContext.Current.Session[Const.IsLogin] != null && HttpContext.Current.Session[Const.IsLogin].ToStringAndTrim().ToBoolean())
            {
                return true;
            }
            else
            {
                httpContext.Response.StatusCode = 401;//无权限状态码
                return false;//只有返回的是false 才会执行HandleUnauthorizedRequest
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectResult("/Home/Index/nologin");
        }
    }
}