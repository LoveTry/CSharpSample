using EverythingWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EverythingWeb.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]//设置全局AuthorizeAttribute时，该特性可以访问ActionResult
        public ActionResult Index()
        {
            //https://www.cnblogs.com/itliuyang/p/6872027.html
            //https://www.cnblogs.com/imstrive/p/6510726.html

            //MVC框架从URL获取到变量的值都可以通过RouteData.Values["xx"]，这个集合访问
            //var id = RouteData.Values["id"].ToStringAndTrim();
            //if (id == "nologin")
            //{
            //    ViewBag.Msg = "没有登录";
            //}
            if (Session[Comm.Const.IsLogin] is null)
            {
                ViewBag.Msg = "没有登录";
            }
            else
            {
                ViewBag.Msg = "已经登录";
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session[Comm.Const.IsLogin] = true;//标记是否已经登录
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session[Comm.Const.IsLogin] = null;//标记是否已经登录
            return RedirectToAction("Index");
        }
        
    }
}