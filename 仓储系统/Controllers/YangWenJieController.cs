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
        //部门管理页面跳转
        public ActionResult buMenGuanLi()
        {
            return View();
        }
        //菜单管理页面跳转
        public ActionResult caiDanGuanLi()
        {
            return View();
        }
        //权限页面跳转
        public ActionResult quanXian()
        {
            return View();
        }
        //分页加载页面
        public ActionResult getDepart(int pageIndex, int pageSize, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                //根据部门名查询
                return Json(DepartManager.getDepartByName(pageIndex, pageSize, name), JsonRequestBehavior.AllowGet);
            }
            else
            {
                //页面加载
                return Json(DepartManager.getDepart(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
            }

        }
        //新增
        public ActionResult Add(Depart det)
        {
            Random random = new Random();
            string n = random.Next(1000000,10000000).ToString();
            det.DepartNum = n;
            det.CreateUser = "DA_0000";
            det.CreateTime = DateTime.Now;
            det.IsDelete = 0;
            return Json(DepartManager.Add(det), JsonRequestBehavior.AllowGet);
        }

        //删除(修改标识Id)
        public ActionResult delDepart(Depart det,int id)
        {
            //det.IsDelete = 1;
            return Json(DepartManager.delDepart(det,id), JsonRequestBehavior.AllowGet);
        }
        //修改
        public ActionResult upDepartById(string DepartName, int id)
        {
            return Json(DepartManager.upDepartById(DepartName, id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult del(int id)
        {
            return Json(DepartManager.del(id), JsonRequestBehavior.AllowGet);
        }
    }
}