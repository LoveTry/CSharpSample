using EverythingWeb.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb.Filter
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session[Const.IsLogin] != null && HttpContext.Current.Session[Const.IsLogin].ToStringAndTrim().ToBoolean())
            {
                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectResult("/Home/Index/nologin");
                base.OnActionExecuting(filterContext);
            }
        }
    }
}