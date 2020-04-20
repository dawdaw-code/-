using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL.Jiajiaxin
{
    public class InStorageService
    {
        public static int AddInStorage(InStorage ie)
        {
            WarehouseEntities entities = new WarehouseEntities();
            entities.InStorage.Add(ie);
            return entities.SaveChanges();
        }

        public static PageList GetQueryInStorage(int pageIndex, int pageSize, InStorage io)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var query = from p in entity.InStorage select p;
            if (!string.IsNullOrEmpty(io.InSNum))
            {
                query = query.Where(p => p.InSNum.Contains(io.InSNum));
            }
            var obj = from p in query
                      orderby p.Id
                      where p.IsDelete == 0
                      select new
                      {
                          Id = p.Id,
                          IsDelete = p.IsDelete,
                          Remark = p.Remark,
                          AuditTime = p.AuditTime,
                          AuditUser = p.AuditUser,
                          DetailNum = p.DetailNum,
                          InSNum = p.InSNum,
                          InSTypeId = p.InSTypeId,
                          Num = p.Num,
                          Operation = p.Operation,
                          Status = p.Status,
                          SumMoney = p.SumMoney,
                          SupplierId = p.SupplierId

                      };
            //设置分页数据
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = query.Count();
            list.PageCount = rows;/*% pageSize == 0 ? rows / pageSize : rows / pageSize + 1;*/
            return list;
        }















    }
}
