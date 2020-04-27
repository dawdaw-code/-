using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL
{
    public class FunctionService
    {
        //public static PageList getFunction(int pageIndex, int pageSize)
        //{
        //    WarehouseEntities con = new WarehouseEntities();
        //    PageList list = new PageList();
        //    var obj = from p in con.Function
        //              where p.IsDelete == 0
        //              select new
        //              {
        //                  NodeId = p.NodeId,
        //                  DisplayName = p.DisplayName,
        //                  NodeURL = p.NodeURL,
        //                  ParentNodeId = p.ParentNodeId,
        //                  CreateUser = p.CreateUser,
        //                  CreateTime = p.CreateTime
        //              };
        //    list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    int rows = obj.Count();
        //    list.PageCount = rows;
        //    return list;
        //}

        public static PageList getFunctionByIdAndName(int pageIndex, int pageSize, string name)
        {
            WarehouseEntities con = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in con.Function
                      where p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          NodeId = p.NodeId,
                          DisplayName = p.DisplayName,
                          NodeURL = p.NodeURL,
                          ParentNodeId = p.ParentNodeId,
                          CreateUser = p.CreateUser,
                          CreateTime = p.CreateTime
                      };
            //判断name是否为空
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    //判断name是否为数字   
                    if (!Char.IsNumber(name, i))
                    {
                        obj = obj.Where(item => item.DisplayName.IndexOf(name) != -1);
                    }
                    else
                    {
                        int Name = int.Parse(name);
                        obj = obj.Where(item => item.DisplayName.IndexOf(name) != -1 || item.NodeId == Name);
                    }
                }
            }
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            int rows = obj.Count();
            list.PageCount = rows;
            return list;
        }



        //新增
        public static int Add(Function fun)
        {
            WarehouseEntities con = new WarehouseEntities();
            con.Function.Add(fun);
            return con.SaveChanges();
        }

        //删除(修改表示ID)
        public static int delFunction(Function fun, int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Function where p.NodeId == id select p).First();
            obj.IsDelete = 1;
            return con.SaveChanges();
        }
        //根据ID查询
        public static List<Function> menuSelectById(int id) {
            WarehouseEntities con = new WarehouseEntities();
            var obj = from p in con.Function where p.NodeId == id select p;
            return obj.ToList();
        }


        //根据id修改
        public static int upFunctionById(Function fun, int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Function where p.NodeId == id select p).First();
            obj.DisplayName = fun.DisplayName;
            obj.NodeURL = fun.NodeURL;
            obj.CreateTime = DateTime.Now; ;
            return con.SaveChanges();
        }
    }
}



