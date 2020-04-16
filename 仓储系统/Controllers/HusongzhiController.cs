using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models1;
namespace 仓储系统.Views
{
    public class HusongzhiController : Controller
    {
        // GET: Husongzhi
        public ActionResult baosun()
        {
            return View();
        }

        //报损加载
        public ActionResult GetBadReport1()
        {
            return Json(BadReportManager.GetBadReport1(), JsonRequestBehavior.AllowGet);
        }
        //报损加载
        public ActionResult GetBadReport(int pageIndex, int pageSize)
        {
            return Json(BadReportManager.GetBadReport(1, 2), JsonRequestBehavior.AllowGet);
        }

        public ActionResult yiku()
        {
            return View();
        }

        public ActionResult pandian()
        {
            return View();
        }

        public ActionResult tuihuo()
        {
            return View();
        }
    }
}