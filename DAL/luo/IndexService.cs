using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
namespace DAL.luo
{
   public class IndexService
    {
        public static IQueryable indexselect(string name,string pwd)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Admin where p.UserName == name && p.Password == pwd
                      select p;
            return obj;
        }
    }
}
