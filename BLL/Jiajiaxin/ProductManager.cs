using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.Jiajiaxin;
namespace BLL.Jiajiaxin
{
    public class ProductManager
    {

        public static PageList GetQueryPro(int pageIndex, int pageSize, Product pc)
        {
            return ProductService.GetQueryPro(pageIndex, pageSize, pc);
        }

        public static int PageCount(int pageSize)
        {
            int a = ProCategoryService.PageCount();
            if (a % pageSize == 0)
            {
                return a / pageSize;
            }
            else
            {
                return a / pageSize + 1;
            }
        }







    }
}
