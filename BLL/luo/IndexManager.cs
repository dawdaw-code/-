using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.luo;
using Models1;
namespace BLL.luo
{
    public class IndexManager
    {
        public static IQueryable indexselect(string name, string pwd)
        {
            return IndexService.indexselect(name,pwd);
        }
    }
}
