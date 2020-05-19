using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{
    public class CheckStockManager
    {
        public static PageList GetCheckStock(int pageIndex, int pageSize, int Status)
        {
            return CheckStockService.GetCheckStock(pageIndex, pageSize, Status);
        }

        public static int GetCheckStockCount()
        {
            return CheckStockService.GetCheckStockCount();
        }
        public static IQueryable GetCheckStockType()
        {
            return CheckStockService.GetCheckStockType();
        }

        public static int CheckStockDel(string CheckNum)
        {
            return CheckStockService.CheckStockDel(CheckNum);
        }

        public static int CheckStockEdit(CheckStock p)
        {
            return CheckStockService.CheckStockEdit(p);
        }

        public static IQueryable GetCheckStockId(string CheckNum)
        {
            return CheckStockService.GetCheckStockId(CheckNum);
        }

        public static int Add1(CheckStock b)
        {
            return CheckStockService.Add(b);
        }
        public static IQueryable GetAll11()
        {
            return CheckStockService.GetAll();
        }
        }
}
