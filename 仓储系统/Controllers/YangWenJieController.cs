using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models1;

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

        public ActionResult getDepart(int pageIndex, int pageSize)
        {
            return Json(DepartManager.getDepart(pageIndex,pageSize), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult selectBuMen()
        //{
        //    return Json(DepartManager.selectAll(),JsonRequestBehavior.AllowGet);

        //}

        public ActionResult Add(Depart det)
        {
            return Json(DepartManager.Add(det), JsonRequestBehavior.AllowGet);
        }

        public ActionResult selectByName(string name)
        {
            return Json(DepartManager.selectByName(name), JsonRequestBehavior.AllowGet);
        }
    }
}