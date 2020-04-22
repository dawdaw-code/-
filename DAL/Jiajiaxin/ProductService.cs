using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL.Jiajiaxin
{
    public class ProductService
    {

        public static PageList GetQueryPro(int pageIndex, int pageSize, Product pc)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var query = from p in entity.Product select p;
            if (!string.IsNullOrEmpty(pc.ProductName))
            {
                query = query.Where(p => p.ProductName.Contains(pc.ProductName));
            }
          
            var obj = from p in query
                      orderby p.Id
                      where p.IsDelete == 0
                      select new
                      {
                          ProductName=p.ProductName,
                          Id = p.Id,
                          IsDelete = p.IsDelete,
                          Remark = p.Remark,
                          CreateUser = p.CreateUser,
                          CreateTime = p.CreateTime,
                          Color = p.Color,
                          InPrice = p.InPrice,
                          LocationId = p.LocationId,
                          MaxNum = p.MaxNum,
                          MeasureId = p.MeasureId,
                          MinNum = p.MinNum,
                          OutPrice = p.OutPrice,
                          PCateId = p.PCateId,
                          ProductNum = p.ProductNum,
                          Size = p.Size
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

        public static int DelPro(Product pc,int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Product where p.Id == id select p).First();
            obj.IsDelete = pc.IsDelete;
            return entities.SaveChanges();
        }









    }
}
