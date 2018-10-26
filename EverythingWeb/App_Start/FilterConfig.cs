using EverythingWeb.Filter;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new UserAuthorize());//全局身份验证 可以通过[AllowAnonymous]特性设置到Action可以访问
            filters.Add(new HandleErrorAttribute());
        }
    }
}
