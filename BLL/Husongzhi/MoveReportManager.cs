using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;
namespace BLL
{

    //移库
   public class MoveReportManager
    {
        public static PageList GetMoveReport(int pageIndex, int pageSize)
        {
            return MoveReportService.GetMoveReport(pageIndex, pageSize);
        }

        public static int GetMoveReportCount()
        {
            return MoveReportService.GetMoveReportCount();
        }
    }
}
