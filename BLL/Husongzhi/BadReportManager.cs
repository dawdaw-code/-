using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{
   public class BadReportManager
    {
        public static IQueryable GetBadReport1()
        {
            return BadReportService.GetBadReport1();
        }
            public static PageList GetBadReport(int pageIndex, int pageSize)
        {
            return BadReportService.GetBadReport(pageIndex, pageSize);
        }
        }
}
