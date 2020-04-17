﻿using System;
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
        public static PageList GetMoveReport(int pageIndex, int pageSize)
        {
            //实例化分页类
            PageList list = new PageList();

            WarehouseEntities entity = new WarehouseEntities();
            var obj = from p in entity.MoveReport
                      orderby p.MoveNum ascending
                      select new
                      {
                          MoveNum = p.MoveNum,
                          MoveTypeId = p.MoveTypeId,
                          Num = p.Num,
                          Status = p.Status,
                          AuditUser = p.AuditUser,
                          AuditTime = p.AuditTime,
                          Remark = p.Remark
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
