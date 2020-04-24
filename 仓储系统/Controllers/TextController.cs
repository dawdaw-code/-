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
            List<Role> list = YuangoManager.juesselect();
            //id是隐藏值，name是显示值
            list.Insert(0, new Role { Id = 0, RoleName = "请选择" });
            ViewBag.RoleId = new SelectList(list, "Id", "RoleName");

            List<Depart> list1 = YuangoManager.bumenselect();
            //id是隐藏值，name是显示值
            list1.Insert(0, new Depart { Id = 0, DepartName = "请选择" });
            ViewBag.DepartId = new SelectList(list1, "Id", "DepartName");
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
        public ActionResult delDepart( int id)
        {
            //det.IsDelete = 1;
            return Json(YuangoManager.delDepart( id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult adminid(int id)
        {
            return Json(YuangoManager.adminid(id),JsonRequestBehavior.AllowGet);
        }
        public ActionResult adminidup(string id, string UserName, string RealName, string Email, string Phone, int DepartId, int RoleId)
        {
            return Json(YuangoManager.adminidup(id, UserName, RealName, Email, Phone, DepartId, RoleId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult getRole(int pageIndex, int pageSize, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                //根据部门名查询
                return Json(jueseManager.getRoleName(pageIndex, pageSize, name), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //页面加载
                return Json(jueseManager.getRolePower(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
            }

        }
        
             public ActionResult delRole(int id)
        {
            //det.IsDelete = 1;
            return Json(jueseManager.delRole(id), JsonRequestBehavior.AllowGet);
        }
    }
}