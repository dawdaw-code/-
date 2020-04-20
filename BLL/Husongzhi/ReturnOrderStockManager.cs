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
        public static PageList GetReturnOrderStock(int pageIndex, int pageSize)
        {
            return ReturnOrderStockService.GetReturnOrderStock(pageIndex, pageSize);
        }
        public static int GetReturnOrderStockCount()
        {
            return ReturnOrderStockService.GetReturnOrderStockCount();
        }
        }
}
