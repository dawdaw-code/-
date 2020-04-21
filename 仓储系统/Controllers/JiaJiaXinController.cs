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

        public ActionResult HidePage()
        {
            return View();
        }


        public ActionResult DelCategory(ProductCategory pc, int id)
        {
            pc.IsDelete = 1;
            return Json(ProCategoryManager.DelCategory(pc,id), JsonRequestBehavior.AllowGet);
        }




        public ActionResult GetQuery(int pageIndex, int pageSize, ProductCategory pc)
        {
            return Json(ProCategoryManager.GetQuery(pageIndex, pageSize,pc), JsonRequestBehavior.AllowGet);
        }

        public ActionResult pageCount(int pageSize)
        {
            return Json(ProCategoryManager.PageCount(pageSize), JsonRequestBehavior.AllowGet);
        }



        //产品管理查询
        public ActionResult GetQueryPro(int pageIndex, int pageSize, Product pc)
        {
            return Json(ProductManager.GetQueryPro(pageIndex,pageSize,pc), JsonRequestBehavior.AllowGet);
        }


        public ActionResult pageCount2(int pageSize)
        {
            return Json(ProductManager.PageCount(pageSize), JsonRequestBehavior.AllowGet);
        }

        //绑定类别
        public ActionResult  GetTypes()
        {
            
            return Json(ProCategoryManager.GetTypes(), JsonRequestBehavior.AllowGet); 
        }


        public ActionResult DelPro(Product pc, int id)
        {
            pc.IsDelete = 1;
            return Json(ProductManager.DelPro(pc, id), JsonRequestBehavior.AllowGet);                
        }



        //新增入库单
        public ActionResult AddInStorage(InStorage ie)
        {
            return Json(InStorageManager.AddInStorage(ie), JsonRequestBehavior.AllowGet);
        }

        //入库单查询
        public ActionResult GetQueryInStorage(int pageIndex, int pageSize, InStorage io)
        {
            return Json(InStorageManager.GetQueryInStorage(pageIndex, pageSize, io), JsonRequestBehavior.AllowGet);
             
        }


        //删除入库单
        public ActionResult DelInStorage(InStorage pc, int id)
        {
            pc.IsDelete = 1;
            return Json(InStorageManager.DelInStorage(pc, id), JsonRequestBehavior.AllowGet);
        }

        //产品类别修改
        public ActionResult GetById(int id)
        {
            return Json(ProCategoryManager.GetById(id), JsonRequestBehavior.AllowGet); 
        }



        public ActionResult EditProductCategory(ProductCategory pc)
        {
            pc.CreateTime = DateTime.Now;
            return Json(ProCategoryManager.EditProductCategory(pc), JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddCategory(ProductCategory pc)
        {
            return Json(ProCategoryManager.AddCategory(pc) ,JsonRequestBehavior.AllowGet);
        }














    }
}