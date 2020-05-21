using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
namespace DAL
{
    //移库
    public class MoveReportService
    {
        //获取总条数
        public static int GetMoveReportCount()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.MoveReport where p.IsDelete == 0 select p).Count();
            return obj;
        }

        public static IQueryable GetMoveReportType()
        {

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.MoveReportType
                      where p.IsDelete == 0
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          MoveTypeName = p.MoveTypeName
                      };
            return obj;
        }

        public static PageList GetMoveReport(int pageIndex, int pageSize, int Status)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.MoveReport
                      where p.IsDelete == 0
                      join b in entity.MoveReportType on p.MoveTypeId equals b.Id
                      orderby p.MoveNum ascending
                      select new
                      {
                          Id = p.Id,
                          MoveNum = p.MoveNum,
                          MoveTypeName=b.MoveTypeName,
                          ProductId =p.ProductId,
                          Num = p.Num,
                          Status = p.Status,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime,
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

        public static PageList GetMoveReportById(int pageIndex, int pageSize, string MoveNum)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.MoveReport
                      where p.IsDelete == 0
                      join b in entity.MoveReportType on p.MoveTypeId equals b.Id
                      orderby p.MoveNum ascending
                      select new
                      {
                          Id = p.Id,
                          MoveNum = p.MoveNum,
                          MoveTypeName = b.MoveTypeName,
                          ProductId = p.ProductId,
                          Num = p.Num,
                          Status = p.Status,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime,
                          Remark = p.Remark
                      };
            var obj1 = obj;
            if (MoveNum != null)
            {
                obj1 = obj.Where(d => d.MoveNum.Contains(MoveNum));

            }
            //设置分页数据
            list.DataList = obj1.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj1.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;


            return list;
        }

        public static int MoveReportDel(string MoveNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.MoveReport where p.MoveNum == MoveNum select p).First();
            //修改
            obj.IsDelete = 1;
            return entity.SaveChanges();
        }

        public static int MoveReportEdit(MoveReport p)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var obj = entity.MoveReport.Find(p.Id);
            obj.MoveTypeId = p.MoveTypeId;
            obj.ProductId = p.ProductId;
            obj.Num = p.Num;
            obj.Status = p.Status;
            obj.AuditUser = p.AuditUser;
            obj.AuditTime = p.AuditTime;
            return entity.SaveChanges();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="BadNum"></param>
        /// <returns></returns>
        public static IQueryable GetMoveReportId(string MoveNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            //先修改主表数据
            var ll = from p in entity.MoveReport
                     where p.MoveNum == MoveNum
                     select new
                     {
                         Id = p.Id,
                         MoveNum = p.MoveNum,
                         MoveTypeId = p.MoveTypeId,
                         ProductId = p.ProductId,
                         Num = p.Num,
                         Status = p.Status,
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
            var obj = from p in entity.MoveReport
                      orderby p.Id ascending
                      select new
                      {
                          Id = p.Id,
                          MoveNum = p.MoveNum,
                      };
            return obj;
        }

        public static int Add(MoveReport b)
        {
            WarehouseEntities entity = new WarehouseEntities();
            entity.MoveReport.Add(b);
            return entity.SaveChanges();
        }
    }
}
