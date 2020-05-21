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
        public static List<Depart> selectAll()
        {
            return DepartService.selectAll();
        }
    }
}
