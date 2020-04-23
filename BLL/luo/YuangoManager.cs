using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.luo;
namespace BLL.luo
{
    public class YuangoManager
    {
        public static IQueryable AdminSelect()
        {
            return YuangoService.AdminSelect();
        }
        public static PageList getDepart(int pageIndex, int pageSize)
        {
            return YuangoService.getDepart(pageIndex, pageSize);
        }
        public static PageList getDepartByName(int pageIndex, int pageSize, string name)
        {
            return YuangoService.getDepartByName(pageIndex, pageSize, name);
        }

        public static int Add(Depart det)
        {
            return YuangoService.Add(det);
        }

        public static int delDepart(int Id)
        {
            return YuangoService.delDepart(Id);
        }

        public static int upDepartById(string DepartName, int id)
        {
            return YuangoService.upDepartById(DepartName, id);
        }
    }
}
