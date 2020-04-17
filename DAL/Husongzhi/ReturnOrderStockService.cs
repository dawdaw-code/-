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
        public static PageList GetReturnOrderStock(int pageIndex, int pageSize)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.ReturnOrderStock
                      orderby p.ReturnNum ascending
                      select new
                      {
                          ReturnNum = p.ReturnNum,
                          ReturnTypeId = p.ReturnTypeId,
                          ProductId = p.ProductId,
                          Num = p.Num,
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
