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
       
       
        public static int DelCategory(ProductCategory pc, int id)
        {
            return ProCategoryService.DelCategory(pc,id);
        }



        public static PageList GetQuery(int pageIndex, int pageSize, ProductCategory pc)
        {
            return ProCategoryService.GetQuery(pageIndex, pageSize, pc);
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




        public static IQueryable GetTypes()
        {
            return ProCategoryService.GetTypes();
        }




        public static IQueryable GetById(int id)
        {
            return ProCategoryService.GetById(id);
        }



        public static int EditProductCategory(ProductCategory pc)
        {
            return ProCategoryService.EditProductCategory(pc);
        }



        public static int AddCategory(ProductCategory pc)
        {
            return ProCategoryService.AddCategory(pc);
        }















    }
}
