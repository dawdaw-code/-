﻿using System;
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
        public ActionResult getDepart
            (int pageIndex, int pageSize,string name)
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
            return Json(DepartManager.Add(det), JsonRequestBehavior.AllowGet);
        }





        //根据部门名查询
        //public ActionResult selectByName(string name)
        //{
        //    //List<Depart> list = DepartManager.selectByName(name);
        //    return Json(DepartManager.selectByName(name), JsonRequestBehavior.AllowGet);
        //}
    }
}