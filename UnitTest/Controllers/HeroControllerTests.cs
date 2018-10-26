using Microsoft.VisualStudio.TestTools.UnitTesting;
using EverythingWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EverythingWeb.Models;

namespace EverythingWeb.Controllers.Tests
{
    [TestClass()]
    public class HeroControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var weapon = new Sword("大宝剑");
            var monster = new Dragon(weapon);
            var controller = new HeroController(monster);
            ContentResult result = controller.Index() as ContentResult;
            Assert.AreEqual("巨龙用大宝剑攻击了我1000点血", result.Content);
            //Assert.IsNotNull(result);
        }
    }
}