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
        public static PageList GetCheckStock(int pageIndex, int pageSize)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.CheckStock
                      orderby p.CheckNum ascending
                      select new
                      {
                          CheckNum = p.CheckNum,
                          CheckTypeId = p.CheckTypeId,
                          DetailNum = p.DetailNum,
                          Status = p.Status,
                          Operation = p.Operation,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime
                      };
            //设置分页数据
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;


            return list;
        }
    }
}
