using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储系统.Controllers
{
    public class YangWenJieController : Controller
    {
        // GET: YangWenJie
        public ActionResult buMenGuanLi()
        {
            return View();
        }

        public ActionResult caiDanGuanLi()
        {
            return View();
        }
        public ActionResult quanXian()
        {
            return View();
        }
    }
}