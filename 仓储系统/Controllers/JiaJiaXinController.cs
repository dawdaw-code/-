using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models1;
using BLL.Jiajiaxin;
namespace 仓储系统.Controllers
{
    public class JiaJiaXinController : Controller
    {
        // GET: JiaJiaXin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult List2()
        {
            return View();
        }


        public ActionResult Rukuguanli()
        {
            return View();
        }
        public ActionResult Chukuguanli()
        {
            return View();
        }
        public ActionResult AddRukudan()
        {
            return View();
        }
        public ActionResult AddChukudan()
        {
            return View();
        }


        //产品类别管理查询
        public ActionResult GetCategory(int pageIndex, int pageSize)
        {
            return Json(ProCategoryManager.GetCategory(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
        }

        public ActionResult QueryCategory()
        {
            return Json(ProCategoryManager.QueryCategory(), JsonRequestBehavior.AllowGet);
        }





    }
}