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
        //public static PageList getDepart(int pageIndex, int pageSize)
        //{
        //    return YuangoService.getDepart(pageIndex, pageSize);
        //}
        public static PageList getDepartByName(int pageIndex, int pageSize, string name)
        {
            return YuangoService.getDepartByName(pageIndex, pageSize, name);
        }
        public static List<Role> juesselect()
        {
            return YuangoService.juesselect();
        }
        public static List<Depart> bumenselect()
        {
            return YuangoService.bumenselect();
        }
        public static IQueryable adminid(int id)
        {
            return YuangoService.adminid(id);
        }
        public static int adminidup(string id, string UserName, string RealName, string Email, string Phone, int DepartId, int RoleId)
        {
            return YuangoService.adminidup( id,  UserName,  RealName,  Email,  Phone,  DepartId,  RoleId);
        }
        public static int delDepart( int id)
        {
            return YuangoService.delDepart( id);
        }
        public static int insert(string UserCode, string UserName, string RealName, string Email, string Phone, int DepartId, int RoleId)
        {
            return YuangoService.insert( UserCode,  UserName,  RealName,  Email,  Phone,  DepartId,  RoleId);
        }
    }
}
