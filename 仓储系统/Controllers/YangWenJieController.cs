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

        //计量单位页面跳转
        public ActionResult jiLiangDanWei()
        {
            return View();
        }

        //
        public ActionResult menuPopup()
        {
            return View();
        }

        //分页加载页面
        public ActionResult getDepart(int pageIndex, int pageSize, string name)
        {
            //if (!string.IsNullOrEmpty(name))
            //{
            //    //根据部门名查询
            //    return Json(DepartManager.getDepartByName(pageIndex, pageSize, name), JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    //页面加载
            //    return Json(DepartManager.getDepart(pageIndex, pageSize), JsonRequestBehavior.AllowGet);
            //}
            return Json(DepartManager.getDepartByName(pageIndex, pageSize, name), JsonRequestBehavior.AllowGet);
        }

        //部门新增
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

        //部门删除(修改标识Id)
        public ActionResult delDepart(int id)
        {
            //det.IsDelete = 1;
            return Json(DepartManager.delDepart(id), JsonRequestBehavior.AllowGet);
        }
        //部门修改
        public ActionResult upDepartById(string DepartName, int id)
        {
            return Json(DepartManager.upDepartById(DepartName, id), JsonRequestBehavior.AllowGet);
        }
        public ActionResult del(int id)
        {
            return Json(DepartManager.del(id), JsonRequestBehavior.AllowGet);
        }





        //菜单管理页面加载和查询
        public ActionResult getFunction(int pageIndex, int pageSize, string name)
        {
                //根据编号或名称查询
                return Json(FunctionManager.getFunctionByIdAndName(pageIndex, pageSize,name), JsonRequestBehavior.AllowGet);
        }

        //菜单删除(修改标识ID)

        public ActionResult delFunction(Function fun ,int id)
        {
            return Json(FunctionManager.delFunction(fun,id), JsonRequestBehavior.AllowGet);
        }

        //菜单根据id查询
        public ActionResult menuSelectById(int id)
        {
            return Json(FunctionManager.menuSelectById(id), JsonRequestBehavior.AllowGet);
        }

        //菜单修改
        public ActionResult upFunctionById(Function fun, int id)
        {
            return Json(FunctionManager.upFunctionById(fun, id), JsonRequestBehavior.AllowGet);
        }
        //菜单新增
        public ActionResult menuAdd(Function fun)
        {
            Random random = new Random();
            int n = random.Next(10000, 100000);
            fun.NodeId = n;
            fun.ParentNodeId = n;
            fun.CreateTime = DateTime.Now;
            fun.IsDelete = 0;
            return Json(FunctionManager.Add(fun), JsonRequestBehavior.AllowGet);
        }



        //计量单位页面加载查询
        public ActionResult getMeasureByName(int pageIndex, int pageSize, string name)
        {
            return Json(MeasureManager.getMeasureByName(pageIndex,pageSize,name),JsonRequestBehavior.AllowGet);
        }

        //菜单删除(修改标识ID)
        public ActionResult delMeasure(int id)
        {
            return Json(MeasureManager.delMeasure(id), JsonRequestBehavior.AllowGet);
        }

        //菜单新增
        public ActionResult AddMeasure(Measure mes)
        {
            Random random = new Random();
            int n = random.Next(100000, 1000000);
            mes.IsDelete = 0;
            mes.CreateTime = DateTime.Now;
            mes.MeasureNum = n.ToString();

            return Json(MeasureManager.AddMeasure(mes), JsonRequestBehavior.AllowGet);
        }


        //菜单根据id查询
        public ActionResult mesSelectById(int id)
        {
            return Json(MeasureManager.mesSelectById(id), JsonRequestBehavior.AllowGet);
        }

        //菜单修改
        public ActionResult upMeasureById(Measure mes, int id)
        {
            return Json(MeasureManager.upMeasureById(mes, id), JsonRequestBehavior.AllowGet);
        }





    }
}