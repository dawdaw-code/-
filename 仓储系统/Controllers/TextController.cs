using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using BLL;
using Models1;
namespace 仓储系统.Controllers
{
    public class TextController : Controller
    {
        // GET: Text
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Indexselect(string name, string pwd)
        {
            return Json(BLL.luo.IndexManager.indexselect(name, pwd),JsonRequestBehavior.AllowGet);
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Zhuti()
        {
            return View();
        }
        public ActionResult Yuango()
        {
            return View();
        }
        public ActionResult Juese()
        {
            return View();
        }
    }
}