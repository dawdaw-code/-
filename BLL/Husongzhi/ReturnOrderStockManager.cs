using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{
   public  class ReturnOrderStockManager
    {
        public static PageList GetReturnOrderStock(int pageIndex, int pageSize, int Status)
        {
            return ReturnOrderStockService.GetReturnOrderStock(pageIndex, pageSize,  Status);
        }
        public static PageList GetReturnOrderStockById(int pageIndex, int pageSize, string ReturnNum)
        {
            return ReturnOrderStockService.GetReturnOrderStockById(pageIndex, pageSize, ReturnNum);
        }
        public static IQueryable ReturnOrderType()
        {
            return ReturnOrderStockService.ReturnOrderType();
        }
        public static int GetReturnOrderStockCount()
        {
            return ReturnOrderStockService.GetReturnOrderStockCount();
        }
        public static int ReturnOrderStockDel(string ReturnNum)
        {
            return ReturnOrderStockService.ReturnOrderStockDel(ReturnNum);
        }
        public static int ReturnOrderStockEdit(ReturnOrderStock p)
        {
            return ReturnOrderStockService.ReturnOrderStockEdit(p);
        }
        public static IQueryable GetReturnOrderStockId(string ReturnNum)
        {
            return ReturnOrderStockService.GetReturnOrderStockId(ReturnNum);
        }
        public static IQueryable GetAll2()
        {
            return ReturnOrderStockService.GetAll();
        }
        public static int Add2(ReturnOrderStock b)
        {
            return ReturnOrderStockService.Add(b);
        }
        }
}
