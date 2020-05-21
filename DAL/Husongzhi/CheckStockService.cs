using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
namespace DAL
{
  public   class CheckStockService
    {
        //获取总条数
        public static int GetCheckStockCount()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.CheckStock where p.IsDelete == 0 select p).Count();
            return obj;
        }
        
        public static IQueryable GetCheckStockType()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.CheckStockType
                      where p.IsDelete == 0
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          MoveTypeName = p.MoveTypeName
                      };
            return obj;
        }

        public static PageList GetCheckStock(int pageIndex, int pageSize, int Status)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.CheckStock
                      where p.IsDelete == 0
                      join b in entity.CheckStockType on p.CheckTypeId equals b.Id
                      orderby p.CheckNum ascending
                      select new
                      {
                          Id = p.Id,
                          CheckNum = p.CheckNum,
                          CheckTypeId = p.CheckTypeId,
                          CheckTypeName = b.MoveTypeName,
                          DetailNum = p.DetailNum,
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

        public static PageList GetCheckStockById(int pageIndex, int pageSize, string CheckNum)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.CheckStock
                      where p.IsDelete == 0
                      join b in entity.CheckStockType on p.CheckTypeId equals b.Id
                      orderby p.CheckNum ascending
                      select new
                      {
                          Id = p.Id,
                          CheckNum = p.CheckNum,
                          CheckTypeId = p.CheckTypeId,
                          CheckTypeName = b.MoveTypeName,
                          DetailNum = p.DetailNum,
                          Status = p.Status,
                          Operation = p.Operation,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime
                      };
            var obj1 = obj;
            if (CheckNum != null)
            {
                obj1 = obj.Where(d => d.CheckNum.Contains(CheckNum));

            }
            //设置分页数据
            list.DataList = obj1.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj1.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;


            return list;
        }

        public static int CheckStockDel(string CheckNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.CheckStock where p.CheckNum == CheckNum select p).First();
            //修改
            obj.IsDelete = 1;
            return entity.SaveChanges();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int CheckStockEdit(CheckStock p)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var obj = entity.CheckStock.Find(p.Id);
            obj.Id = p.Id;
            obj.CheckNum = p.CheckNum;
            obj.CheckTypeId = p.CheckTypeId;
            obj.CheckTypeId = p.CheckTypeId;
            obj.DetailNum = p.DetailNum;
            obj.Status = p.Status;
            obj.Operation = p.Operation;
            obj.AuditUser = p.AuditUser;
            obj.AuditTime = p.AuditTime;
            return entity.SaveChanges();
        }

        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="BadNum"></param>
        /// <returns></returns>
        public static IQueryable GetCheckStockId(string CheckNum)
        {

            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var ll = from p in entity.CheckStock
                     where p.CheckNum == CheckNum
                     select new
                     {
                         Id = p.Id,
                         CheckNum = p.CheckNum,
                         CheckTypeId = p.CheckTypeId,
                         ProductId = p.ProductId,
                         //BadTypeName= BadReportType.BadTypeName,
                         DetailNum = p.DetailNum,
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
            var obj = from p in entity.CheckStock
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          CheckNum = p.CheckNum,
                      };
            return obj;
        }

        public static int Add(CheckStock b)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.CheckStock.Add(b);
            return entity.SaveChanges();
        }
    }
}

