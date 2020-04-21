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






        public static PageList GetQuery(int pageIndex, int pageSize, ProductCategory pc)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var query = from p in entity.ProductCategory select p;
            if (!string.IsNullOrEmpty(pc.PCateName))
            {
                query = query.Where(p => p.PCateName.Contains(pc.PCateName));
            }
            var obj = from p in query
                      orderby p.Id
                      where p.IsDelete == 0
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
            int rows = query.Count();
            list.PageCount = rows;/*% pageSize == 0 ? rows / pageSize : rows / pageSize + 1;*/
            return list;
        }





        public static int PageCount()
        {
            WarehouseEntities entities = new WarehouseEntities();
            return (from p in entities.ProductCategory select p).Count();
        }

















        public static int AddCategory(ProductCategory pc)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.ProductCategory.Add(pc);
            return entity.SaveChanges();
        }


        //修改产品状态(删除)
        public static int DelCategory(ProductCategory pc, int id)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.ProductCategory where p.Id == id select p).First();
            obj.IsDelete = pc.IsDelete;
            return entity.SaveChanges();
        }



        public static IQueryable GetTypes()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ProductCategory
                      select new
                      {
                          Id = p.Id,
                          PCateName = p.PCateName
                      };
            return obj;
        }



        public static IQueryable GetById(int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.ProductCategory
                      where p.Id == id
                      select new
                      {
                          Id = p.Id,
                          PCateName = p.PCateName,
                          Remark = p.Remark
                      };
            return obj;
        }




        public static int EditProductCategory(ProductCategory pc)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.ProductCategory
                       where p.Id == pc.Id
                       select p).First();
            obj.Id = pc.Id;
            obj.PCateName = pc.PCateName;
            obj.Remark = pc.Remark;
            obj.CreateTime = pc.CreateTime;
            return entities.SaveChanges();
        }











    }
}
