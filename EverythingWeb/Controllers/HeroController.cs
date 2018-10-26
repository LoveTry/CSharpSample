using Autofac.Core;
using EverythingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingWeb.Controllers
{
    public class HeroController : Controller
    {
        public IMonster Monster { get; set; }
        public HeroController(IMonster monster)
        {
            Monster = monster;
        }
        // GET: Hero
        public ActionResult Index()
        {
            //使用依赖注入
            string content = string.Concat(Monster.MyName(), "用", Monster.MyWeapon(), "攻击了我", Monster.Attack().ToString(), "点血");
            return Content(content);
        }
    }
}