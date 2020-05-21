using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using System.Text.RegularExpressions;
namespace DAL
{
    //报损
    public class BadReportService
    {
        //获取总条数
        public static int GetBadReportCount()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.BadReport where p.IsDelete == 0 select p).Count();
            return obj;
        }



        /// <summary>
        /// 加载报损类型
        /// </summary>
        /// <returns></returns>
        public static IQueryable GetBadReportType()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.BadReportType
                      where p.IsDelete == 0
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          BadTypeName = p.BadTypeName
                      };
            return obj;
        }


        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static PageList GetBadReport(int pageIndex, int pageSize, int Status)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.BadReport
                      where p.IsDelete == 0
                      join b in entity.BadReportType on p.BadTypeId equals b.Id
                      orderby p.BadNum ascending
                      select new
                      {
                          Id = p.Id,
                          BadNum = p.BadNum,
                          BadTypeId = p.BadTypeId,
                          BadTypeName = b.BadTypeName,
                          DetailNum = p.DetailNum,
                          Num = p.Num,
                          SumMoney = p.SumMoney,
                          Status = p.Status,
                          Operation = p.Operation,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime,
                          IsDelete = p.IsDelete,
                          Remark = p.Remark

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

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public static PageList GetById(int pageIndex, int pageSize,string BadNum)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.BadReport
                      where p.IsDelete == 0
                      join b in entity.BadReportType on p.BadTypeId equals b.Id
                      orderby p.BadNum ascending
                      select new
                      {
                          Id = p.Id,
                          BadNum = p.BadNum,
                          BadTypeId = p.BadTypeId,
                          BadTypeName = b.BadTypeName,
                          DetailNum = p.DetailNum,
                          Num = p.Num,
                          SumMoney = p.SumMoney,
                          Status = p.Status,
                          Operation = p.Operation,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime,
                          IsDelete = p.IsDelete,
                          Remark = p.Remark

                      };
            var obj1 = obj;

                if (BadNum != null)
                {
                    obj1 = obj.Where(d => d.BadNum.Contains(BadNum));
                }
            
            //设置分页数据
            list.DataList = obj1.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj1.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;
            return list;
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="BadNum"></param>
        /// <returns></returns>
        public static int BadReportDel(string BadNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.BadReport where p.BadNum == BadNum select p).First();
            //修改
            obj.IsDelete = 1;
            return entity.SaveChanges();
        }

        //public static int DelAll(List<T> li)
        //{
        //    WarehouseEntities entity = new WarehouseEntities();
        //    var obj = (from p in entity.BadReport where p.BadNum == BadNum select p).First();
        //    //修改
        //    obj.IsDelete = 1;
        //    return entity.SaveChanges();
        //}


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static int Edit(BadReport p)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var obj = entity.BadReport.Find(p.Id);
            obj.BadTypeId = p.BadTypeId;
            obj.ProductId = p.ProductId;
            obj.Num = p.Num;
            obj.SumMoney = p.SumMoney;
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
        public static IQueryable GetBadReportId(string BadNum)
        {

            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var ll = from p in entity.BadReport
                     where p.BadNum == BadNum
                     select new
                     {
                         Id = p.Id,
                         BadNum = p.BadNum,
                         BadTypeId = p.BadTypeId,
                         ProductId = p.ProductId,
                         //BadTypeName= BadReportType.BadTypeName,
                         Num = p.Num,
                         SumMoney = p.SumMoney,
                         Status = p.Status,
                         Operation = p.Operation,
                         AuditUser = p.AuditUser,
                         AuditTime = p.AuditTime,
                         IsDelete = p.IsDelete,
                         Remark = p.Remark
                     };
            return ll;
        }


        public static IQueryable Product(string ProductName)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.Product
                      
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          ProductNum = p.ProductNum,
                          ProductName = p.ProductName,
                          Size = p.Size,
                          Color = p.Color,
                          OutPrice = p.OutPrice
                      };
            if (ProductName!=null) {
              obj= obj.Where(p =>p.ProductName.Contains(ProductName));
            }
            return obj;
        }
        public static IQueryable Product1()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.Product
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          ProductNum = p.ProductNum,
                          ProductName = p.ProductName,
                          Size = p.Size,
                          Color = p.Color,
                          OutPrice = p.OutPrice
                      };

            return obj;
        }

        public static IQueryable Product2(int id)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.Product
                      where p.Id == id
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          ProductNum = p.ProductNum,
                          ProductName = p.ProductName,
                          Size = p.Size,
                          Color = p.Color,
                          OutPrice = p.OutPrice
                      };
            return obj;
        }


        public static int Add(BadReport b)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.BadReport.Add(b);
            return entity.SaveChanges();
        }

        public static IQueryable GetAll()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.BadReport
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          BadNum = p.BadNum,
                      };
            return obj;
        }
    }
}
