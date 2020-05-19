using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.Jiajiaxin;
namespace BLL.Jiajiaxin
{
    public class InStorageManager
    {
        public static int AddInStorage(InStorage ie)
        {
            return InStorageService.AddInStorage(ie);
        }



        public static PageList GetQueryInStorage(int pageIndex, int pageSize, InStorage io)
        {
            return InStorageService.GetQueryInStorage(pageIndex, pageSize, io);
        }


        public static int DelInStorage(InStorage pc, int id)
        {
            return InStorageService.DelInStorage(pc, id);
        }








    }
}