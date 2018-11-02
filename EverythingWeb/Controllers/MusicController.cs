using EverythingWeb.Entity;
using EverythingWeb.Filter;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb.Controllers
{
    public class MusicController : Controller
    {
        MyContext context = new MyContext();

        public ActionResult Search()
        {
            if (Request.Params["q"] != null)
            {
                var q = Request.Params["q"].ToString().Trim();
                var list = context.Musics.Where(a => a.Name.Contains(q)).Take(10);
                return View(list.ToList());
            }
            else
                return View(context.Musics.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetCode();
            var model = new Musics();
            return View(model);
        }

        [UserFilter]
        [HttpPost]
        public ActionResult Create(Musics model)
        {

            if (model.Name.IsEmpty())
            {
                ModelState.AddModelError(nameof(model.Name), "请输入音乐名称.");
            }
            if (model.Singer.IsEmpty())
            {
                ModelState.AddModelError(nameof(model.Singer), "请输入演唱人.");
            }

            if (ModelState.IsValid)
            {
                model.ID = Guid.NewGuid();
                context.Entry(model).State = EntityState.Added;
                context.SaveChanges();
                return RedirectToAction("Search");
            }
            else
            {
                GetCode();
                return View(model);
            }
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            //只能通过@Html.Action()才能执行，/Music/Menu此URL是执行不了的。
            return PartialView();
        }

        [UserAuthorize]
        public ActionResult DownLoad()
        {
            return Content("正在下载");
        }

        [Route("name/{id:int}")]
        public ActionResult RouteDemo(int id)
        {
            //只有参数为int类型才会匹配
            return View();
        }

        [Route("name/{id}")]
        public ActionResult RouteDemo(string id)
        {
            return View();
        }

        private void GetCode()
        {
            //ViewBag.MusicStyleList = from row in context.MusicStyles
            //                         select new SelectListItem
            //                         {
            //                             Text = row.StyleName,
            //                             Value = row.StyleID.ToString()
            //                         };

            try
            {
                ViewBag.MusicStyleList = new SelectList(context.MusicStyles.OrderBy(o => o.StyleName), "StyleID", "StyleName", "");
            }
            catch when (context.MusicStyles.Count() == 0)
            {
                ViewBag.MusicStyleList = new SelectListItem();
            }


        }

        //定义元组
        private Tuple<string, string> GetData(int a, int b)
        {
            return Tuple.Create<string, string>(a.ToString(), b.ToString());
        }

        private void AutoRandom()
        {
            var query = context.Musics.OrderBy(a => Guid.NewGuid()).First();
        }
    }
}