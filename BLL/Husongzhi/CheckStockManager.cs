using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{
   public  class CheckStockManager
    {
        public static PageList GetCheckStock(int pageIndex, int pageSize)
        {
            return CheckStockService.GetCheckStock(pageIndex, pageSize);
        }
    }
}
