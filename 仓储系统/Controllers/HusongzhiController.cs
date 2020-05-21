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

        public ActionResult Product(string ProductName)
        {
            return Json(BadReportManager.Product(ProductName), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Product1()
        {
            return Json(BadReportManager.Product1(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductID(int id1)
        {
            return Json(BadReportManager.Product2(id1), JsonRequestBehavior.AllowGet);
        }


        //报损
        public ActionResult baosun()
        {
            return View();
        }
        //报损添加
        public ActionResult baosunAdd()
        {
            return View();
        }
        //报损加载
        public ActionResult GetBadReport(int pageIndex, int pageSize ,int Status)
        {
            return Json(BadReportManager.GetBadReport(pageIndex, pageSize, Status), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int pageIndex, int pageSize, string BadNum)
        {
            return Json(BadReportManager.GetById(pageIndex, pageSize, BadNum), JsonRequestBehavior.AllowGet);
        }
        //获取总条数
        public ActionResult GetBadReportCount()
        {
            return Json(BadReportManager.GetBadReportCount(), JsonRequestBehavior.AllowGet);
        }
        //报损删除（改变状态）
        public ActionResult BadReportDel(string BadNum)
        {
            return Json(BadReportManager.BadReportDel(BadNum), JsonRequestBehavior.AllowGet);
        }
        //报损修改
        public ActionResult Edit(BadReport bad)
        {
            return Json(BadReportManager.Edit(bad), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBadReportId(string BadNum)
        {
            return Json(BadReportManager.GetBadReportId(BadNum), JsonRequestBehavior.AllowGet);
        }
        //加载报损类型
        public ActionResult GetBadReportType()
        {
            return Json(BadReportManager.GetBadReportType(), JsonRequestBehavior.AllowGet);
        }
        //
        public ActionResult GetAll()
        {
            return Json(BadReportManager.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(BadReport b)
        {
            b.DetailNum = "1";
            b.IsDelete = 0;
            b.Operation = "电脑";

            return Json(BadReportManager.Add(b), JsonRequestBehavior.AllowGet);
        }


        //移库
        public ActionResult yiku()
        {
            return View();
        }
        //移库添加
        public ActionResult yikuAdd() {
            return View();
        }
        //移库加载
        public ActionResult GetMoveReport(int pageIndex, int pageSize, int Status)
        {
            return Json(MoveReportManager.GetMoveReport(pageIndex, pageSize,  Status), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMoveReportById(int pageIndex, int pageSize, string MoveNum)
        {
            return Json(MoveReportManager.GetMoveReportById(pageIndex, pageSize, MoveNum), JsonRequestBehavior.AllowGet);
        }
        //获取总条数
        public ActionResult GetMoveReportCount()
        {
            return Json(MoveReportManager.GetMoveReportCount(), JsonRequestBehavior.AllowGet);
        }
        //移库删除（改变状态）
        public ActionResult MoveReportDel(string MoveNum)
        {
            return Json(MoveReportManager.MoveReportDel(MoveNum), JsonRequestBehavior.AllowGet);
        }//移库修改
        public ActionResult MoveReportEdit(MoveReport bad)
        {
            return Json(MoveReportManager.MoveReportEdit(bad), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMoveReportId(string CheckNum)
        {
            return Json(MoveReportManager.GetMoveReportId(CheckNum), JsonRequestBehavior.AllowGet);
        }
        //加载类型
        public ActionResult GetMoveReportType()
        {
            return Json(MoveReportManager.GetMoveReportType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll3()
        {
            return Json(MoveReportManager.GetAll3(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add3(MoveReport b)
        {
            b.DetailNum = "1";
            b.IsDelete = 0;
            return Json(MoveReportManager.Add3(b), JsonRequestBehavior.AllowGet);
        }


        //盘点
        public ActionResult pandian()
        {
            return View();
        }
        //盘点添加
        public ActionResult pandianAdd()
        {
            return View();
        }
        //盘点加载
        public ActionResult GetCheckStock(int pageIndex, int pageSize, int Status)
        {
            return Json(CheckStockManager.GetCheckStock(pageIndex, pageSize,  Status), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCheckStockById(int pageIndex, int pageSize, string CheckNum)
        {
            return Json(CheckStockManager.GetCheckStockById(pageIndex, pageSize, CheckNum), JsonRequestBehavior.AllowGet);
        }
        //获取总条数
        public ActionResult GetCheckStockCount()
        {
            return Json(CheckStockManager.GetCheckStockCount(), JsonRequestBehavior.AllowGet);
        }
        //盘点删除（改变状态）
        public ActionResult CheckStockDel(string CheckNum)
        {
            return Json(CheckStockManager.CheckStockDel(CheckNum), JsonRequestBehavior.AllowGet);
        }
        //盘点修改
        public ActionResult CheckStockEdit(CheckStock bad)
        {
            return Json(CheckStockManager.CheckStockEdit(bad), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCheckStockId(string CheckNum)
        {
            return Json(CheckStockManager.GetCheckStockId(CheckNum), JsonRequestBehavior.AllowGet);
        }
        //加载类型
        public ActionResult GetCheckStockType()
        {
            return Json(CheckStockManager.GetCheckStockType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll1()
        {
            return Json(CheckStockManager.GetAll11(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add1(CheckStock b)
        {
            b.DetailNum = "1";
            b.IsDelete = 0;
            b.Operation = "电脑";

            return Json(CheckStockManager.Add1(b), JsonRequestBehavior.AllowGet);
        }


        //退货
        public ActionResult tuihuo()
        {
            return View();
        }
        //退货添加
        public ActionResult tuihuoAdd()
        {
            return View();
        }
        //退货加载
        public ActionResult GetReturnOrderStock(int pageIndex, int pageSize, int Status)
        {
            return Json(ReturnOrderStockManager.GetReturnOrderStock(pageIndex, pageSize,  Status), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReturnOrderStockById(int pageIndex, int pageSize, string ReturnNum)
        {
            return Json(ReturnOrderStockManager.GetReturnOrderStockById(pageIndex, pageSize, ReturnNum), JsonRequestBehavior.AllowGet);
        }
        //获取总条数
        public ActionResult GetReturnOrderStockCount()
        {
            return Json(ReturnOrderStockManager.GetReturnOrderStockCount(), JsonRequestBehavior.AllowGet);
        }
        //退货删除（改变状态）
        public ActionResult ReturnOrderStockDel(string ReturnNum)
        {
            return Json(ReturnOrderStockManager.ReturnOrderStockDel(ReturnNum), JsonRequestBehavior.AllowGet);
        }
        //退货修改
        public ActionResult ReturnOrderStockEdit(ReturnOrderStock bad)
        {
            return Json(ReturnOrderStockManager.ReturnOrderStockEdit(bad), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetReturnOrderStockId(string ReturnNum)
        {
            return Json(ReturnOrderStockManager.GetReturnOrderStockId(ReturnNum), JsonRequestBehavior.AllowGet);
        }
        //加载类型
        public ActionResult ReturnOrderType()
        {
            return Json(ReturnOrderStockManager.ReturnOrderType(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll2()
        {
            return Json(ReturnOrderStockManager.GetAll2(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add2(ReturnOrderStock b)
        {
            b.DetailNum = "1";
            b.IsDelete = 0;
            b.Operation = "电脑";
            return Json(ReturnOrderStockManager.Add2(b), JsonRequestBehavior.AllowGet);
        }
    }
}