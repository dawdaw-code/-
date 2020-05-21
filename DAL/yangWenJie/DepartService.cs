using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL
{
    public class DepartService
    {
        public static List<Depart> selectAll()
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = from p in con.Depart select p;
            return obj.ToList();
        }
    }
}
