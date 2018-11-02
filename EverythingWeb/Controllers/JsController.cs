using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb.Controllers
{
    public class JsController : Controller
    {
        // GET: Js
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}