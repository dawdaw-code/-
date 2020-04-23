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


        public static int DelPro(Product pc, int id)
        {
            return ProductService.DelPro(pc,id);
        }


        //绑定客户下拉框
        public static IQueryable BindCustomer()
        {
            return ProductService.BindCustomer();
        }

        //绑定计量单位下拉框
        public static IQueryable BindMeasure()
        {
            return ProductService.BindMeasure();
        }
        //绑定仓库
        public static IQueryable BindStorage()
        {
            return ProductService.BindStorage();
        }
        //绑定库位
        public static IQueryable BindLocation()
        {
            return ProductService.BindLocation();
        }











        }
}
