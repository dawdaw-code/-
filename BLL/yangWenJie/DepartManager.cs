using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;

namespace BLL
{
    public class DepartManager
    {
        public static PageList getDepart(int pageIndex, int pageSize)
        {
            return DepartService.getDepart(pageIndex, pageSize);
        }
        public static PageList getDepartByName(int pageIndex, int pageSize, string name)
        {
            return DepartService.getDepartByName(pageIndex, pageSize, name);
        }

        public static int Add(Depart det)
        {
            return DepartService.Add(det);
        }

        public static int delDepart(Depart det, int id)
        {
            return DepartService.delDepart(det, id);
        }

        public static int upDepartById(string DepartName, int id)
        {
            return DepartService.upDepartById(DepartName, id);
        }
            //public static List<Depart> selectByName(string name)
            //{
            //    return DepartService.selectByName(name);
            //}
        }
}
