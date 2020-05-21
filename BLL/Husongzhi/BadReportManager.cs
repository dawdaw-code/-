using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{
    //报损
    public class BadReportManager
    {
        public static PageList GetBadReport(int pageIndex, int pageSize, int Status)
        {
            return BadReportService.GetBadReport(pageIndex, pageSize,Status);
        }

        public static PageList GetById(int pageIndex, int pageSize, string BadNum)
        {
            return BadReportService.GetById(pageIndex, pageSize, BadNum);
        }

            public static IQueryable GetBadReportType()
        {
            return BadReportService.GetBadReportType();
        }

            public static int BadReportDel(string BadNum)
        {
            return BadReportService.BadReportDel(BadNum);
        }

        public static int GetBadReportCount()
        {
            return BadReportService.GetBadReportCount();
        }

        public static int Edit(BadReport p)
        {
            return BadReportService.Edit(p);
        }

        public static IQueryable GetBadReportId(string BadNum)
        {
            return BadReportService.GetBadReportId( BadNum);
        }

        public static IQueryable Product(string ProductName)
        {
            return BadReportService.Product(ProductName);
        }
        public static IQueryable Product1()
        {
            return BadReportService.Product1();
        }

        public static IQueryable Product2(int id)
        {
            return BadReportService.Product2(id);
        }

        public static IQueryable GetAll()
        {
            return BadReportService.GetAll();
        }
        public static int Add(BadReport b)
        {

            return BadReportService.Add(b);
        }
        }
}
