using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;

namespace BLL
{
    public class FunctionManager
    {
        //public static PageList getFunction(int pageIndex, int pageSize)
        //{
        //    return FunctionService.getFunction(pageIndex, pageSize);
        //}

        public static PageList getFunctionByIdAndName(int pageIndex, int pageSize, string name)
        {
            return FunctionService.getFunctionByIdAndName(pageIndex, pageSize, name);
        }
        public static int delFunction(Function fun, int id)
        {
            return FunctionService.delFunction(fun, id);
        }
        public static int Add(Function fun)
        {
            return FunctionService.Add(fun);
        }

        public static List<Function> menuSelectById(int id)
        {
            return FunctionService.menuSelectById(id);
        }

        public static int upFunctionById(Function fun, int id)
        {
            return FunctionService.upFunctionById(fun, id);
        }
    }
}