using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
namespace DAL
{
    //报损
    public class BadReportService
    {
        //获取总条数
        public static int GetBadReportCount()
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.BadReport select p).Count();
            return obj;
        }



            public static PageList GetBadReport(int pageIndex, int pageSize)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.BadReport
                      where p.IsDelete == 0  
                      orderby p.BadNum ascending
                      select new
                      {
                          BadNum = p.BadNum,
                          BadTypeId = p.BadTypeId,
                          ProductId=p.ProductId,
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
            //设置分页数据
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;
            return list;
        }

        public static int BadReportEdit(string BadNum)
        {
            WarehouseEntities entity = new WarehouseEntities();
            var obj = (from p in entity.BadReport where p.BadNum ==BadNum select p).First();
            //修改
            obj.IsDelete = 1;
            return entity.SaveChanges();
        }
    }
}
