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
        public static PageList GetMoveReport(int pageIndex, int pageSize, int Status)
        {
            return MoveReportService.GetMoveReport(pageIndex, pageSize,  Status);
        }
        public static IQueryable GetMoveReportType()
        {
            return MoveReportService.GetMoveReportType();
        }
        public static int GetMoveReportCount()
        {
            return MoveReportService.GetMoveReportCount();
        }

        public static int MoveReportDel(string MoveNum)
        {
            return MoveReportService.MoveReportDel(MoveNum);
        }
        public static IQueryable GetMoveReportId(string MoveNum)
        {
            return MoveReportService.GetMoveReportId(MoveNum);
        }
        public static int MoveReportEdit(MoveReport p)
        {
            return MoveReportService.MoveReportEdit(p);
        }
        public static IQueryable GetAll3()
        {
            return MoveReportService.GetAll();
        }
        public static int Add3(MoveReport b)
        {
            return MoveReportService.Add(b);
        }
    }
}
