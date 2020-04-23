using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
using BLL.luo;
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
        public ActionResult AdminSelect()
        {
            return Json(YuangoManager.AdminSelect(),JsonRequestBehavior.AllowGet);
        }
        public ActionResult getDepart(int pageIndex, int pageSize, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                //根据部门名查询
                return Json(YuangoManager.getDepartByName(pageIndex, pageSize, name), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //页面加载
                return Json(YuangoManager.getDepart(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
            }

        }
        //新增
        public ActionResult Add(Depart det)
        {
            return Json(YuangoManager.Add(det), JsonRequestBehavior.AllowGet);
        }

        //删除(修改标识Id)
        public ActionResult delDepart(int Id)
        {
            //det.IsDelete = 1;
            return Json(YuangoManager.delDepart(Id), JsonRequestBehavior.AllowGet);
        }
        //修改
        public ActionResult upDepartById(string DepartName, int id)
        {
            return Json(YuangoManager.upDepartById(DepartName, id), JsonRequestBehavior.AllowGet);
        }
    }
}