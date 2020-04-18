using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL.Jiajiaxin
{
    public class ProCategoryService
    {
        public static IQueryable QueryCategory()
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.ProductCategory
                      select new
                      {
                          Id = p.Id,
                          IsDelete = p.IsDelete,
                          PCateName = p.PCateName,
                          PCateNum = p.PCateNum,
                          Remark = p.Remark,
                          CreateUser = p.CreateUser,
                          CreateTime = p.CreateTime
                      };
            return obj;
        }



        public static PageList GetCategory(int pageIndex, int pageSize)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ProductCategory
                      orderby p.Id 
                      select new
                      {
                          Id = p.Id,
                          IsDelete = p.IsDelete,
                          PCateName = p.PCateName,
                          PCateNum = p.PCateNum,
                          Remark = p.Remark,
                          CreateUser = p.CreateUser,
                          CreateTime = p.CreateTime
                      };
            //设置分页数据
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;
            return list;
        }




        public static int AddCategory(ProductCategory pc)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.ProductCategory.Add(pc);
            return entity.SaveChanges();
        }



        public static int DeleteCategory(int id)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.ProductCategory where p.Id == id select p).First();
            entity.ProductCategory.Remove(obj);
            return entity.SaveChanges();
        }




















    }
}
