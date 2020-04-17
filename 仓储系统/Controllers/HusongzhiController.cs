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
        //报损
        public ActionResult baosun()
        {
            return View();
        }
        //报损加载
        public ActionResult GetBadReport(int pageIndex, int pageSize)
        {
            return Json(BadReportManager.GetBadReport(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
        }

        //移库
        public ActionResult yiku()
        {
            return View();
        }
        //移库加载
        public ActionResult GetMoveReport(int pageIndex, int pageSize)
        {
            return Json(MoveReportManager.GetMoveReport(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
        }

        //盘点
        public ActionResult pandian()
        {
            return View();
        }
        //盘点加载
        public ActionResult GetCheckStock(int pageIndex, int pageSize)
        {
            return Json(CheckStockManager.GetCheckStock(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
        }


        //退货
        public ActionResult tuihuo()
        {
            return View();
        }
        //退货加载
        public ActionResult GetReturnOrderStock(int pageIndex, int pageSize)
        {
            return Json(ReturnOrderStockManager.GetReturnOrderStock(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
        }
    }
}