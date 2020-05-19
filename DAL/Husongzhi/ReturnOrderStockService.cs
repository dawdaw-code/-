using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL
{
    //退货
    public class ReturnOrderStockService
    {
        //获取总条数
        public static int GetReturnOrderStockCount()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.ReturnOrderStock where p.IsDelete == 0 select p).Count();
            return obj;
        }

        public static IQueryable ReturnOrderType()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ReturnOrderType
                      where p.IsDelete == 0
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          ReturnTypeName = p.ReturnTypeName
                      };
            return obj;
        }

        public static PageList GetReturnOrderStock(int pageIndex, int pageSize, int Status)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ReturnOrderStock
                      where p.IsDelete == 0
                      join b in entity.ReturnOrderType on p.ReturnTypeId equals b.Id
                      orderby p.ReturnNum ascending
                      select new
                      {
                          Id = p.Id,
                          ReturnNum = p.ReturnNum,
                          ReturnTypeName=b.ReturnTypeName,
                          ProductId = p.ProductId,
                          Num = p.Num,
                          Status = p.Status,
                          Operation = p.Operation,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime
                      };
            var obj1 = obj;
            if (Status != 0)
            {
                if (Status == 1)
                {
                    obj1 = obj;
                }
                if (Status == 2)
                {
                    obj1 = obj.Where(d => d.Status == "等待审核");
                }
                if (Status == 3)
                {
                    obj1 = obj.Where(d => d.Status == "审核通过");
                }
                if (Status == 4)
                {
                    obj1 = obj.Where(d => d.Status == "审核失败");
                }

            }
            //设置分页数据
            list.DataList = obj1.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj1.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;


            return list;
        }

        public static int ReturnOrderStockDel(string ReturnNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.ReturnOrderStock where p.ReturnNum == ReturnNum select p).First();
            //修改
            obj.IsDelete = 1;
            return entity.SaveChanges();
        }

        public static int ReturnOrderStockEdit(ReturnOrderStock p)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var obj = entity.ReturnOrderStock.Find(p.Id);
            obj.ReturnTypeId = p.ReturnTypeId;
            obj.ProductId = p.ProductId;
            obj.Num = p.Num;
            obj.Status = p.Status;
            obj.Operation = p.Operation;
            obj.AuditUser = p.AuditUser;
            obj.AuditTime = p.AuditTime;
            return entity.SaveChanges();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="BadNum"></param>
        /// <returns></returns>
        public static IQueryable GetReturnOrderStockId(string ReturnNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var ll = from p in entity.ReturnOrderStock
                     where p.ReturnNum == ReturnNum
                     select new
                     {
                         Id = p.Id,
                         ReturnNum = p.ReturnNum,
                         ReturnTypeId = p.ReturnTypeId,
                         ProductId = p.ProductId,
                         Num = p.Num,
                         Status = p.Status,
                         Operation = p.Operation,
                         AuditUser = p.AuditUser,
                         AuditTime = p.AuditTime,
                         IsDelete = p.IsDelete,
                         Remark = p.Remark
                     };
            return ll;
        }

        public static IQueryable GetAll()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ReturnOrderStock
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          ReturnNum = p.ReturnNum,
                      };
            return obj;
        }

        public static int Add(ReturnOrderStock b)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.ReturnOrderStock.Add(b);
            return entity.SaveChanges();
        }
    }
}
