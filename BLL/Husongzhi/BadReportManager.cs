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
        public static PageList GetBadReport(int pageIndex, int pageSize)
        {
            return BadReportService.GetBadReport(pageIndex, pageSize);
        }

        public static int BadReportEdit(string BadNum)
        {
            return BadReportService.BadReportEdit(BadNum);
        }

        public static int  GetBadReportCount()
        {
            return BadReportService.GetBadReportCount();
        }
        }
}
