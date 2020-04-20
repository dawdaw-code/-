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
        //public static List<Depart> selectAll()
        //{
        //    return DepartService.selectAll();
        //}
        public static PageList getDepart(int pageIndex, int pageSize)
        {
            return DepartService.getDepart(pageIndex, pageSize);
        }

        public static int Add(Depart det)
        {
            return DepartService.Add(det);
        }

        public static Depart selectByName(string name)
        {
            return DepartService.selectByName(name);
        }
    }
}
