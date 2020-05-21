using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.luo;
namespace BLL.luo
{
    public class jueseManager
    {
        public static PageList getRolePower(int pageIndex, int pageSize)
        {
            return jueseService.getRolePower(pageIndex, pageSize);
        }
        public static PageList getRoleName(int pageIndex, int pageSize, string name)
        {
            return jueseService.getRoleName(pageIndex, pageSize, name);
        }
        public static int delRole( int id)
        {
            return jueseService.delRole(id);
        }
        public static IQueryable Role(int id)
        {
            return jueseService.Role(id);
        }
        public static int update(string id, string RoleName, string Remark)
        {
            return jueseService.update(id ,RoleName,Remark);
        }
        public static int insert(string RoleNum, string RoleName, string Remark)
        {
            return jueseService.insert(RoleNum, RoleName, Remark);
        }
    }
}
