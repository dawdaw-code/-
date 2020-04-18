using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.Jiajiaxin;
namespace BLL.Jiajiaxin
{
    public class ProCategoryManager
    {
        public static PageList GetCategory(int pageIndex, int pageSize)
        {
            return ProCategoryService.GetCategory(pageIndex, pageSize);
        }
        public static IQueryable QueryCategory()
        {
            return ProCategoryService.QueryCategory();
        }

    }
}
