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
        
        public static PageList getDepartByName(int pageIndex, int pageSize, string name)
        {
            return DepartService.getDepartByName(pageIndex, pageSize, name);
        }

        public static int Add(Depart det)
        {
            return DepartService.Add(det);
        }

        public static int delDepart(int id)
        {
            return DepartService.delDepart(id);
        }

        public static int upDepartById(string DepartName, int id)
        {
            return DepartService.upDepartById(DepartName, id);
        }

        public static int del(int id)
        {
            return DepartService.del(id);
        }
    }
}
