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
        //根据部门名查询
        public static PageList getDepartByName(int pageIndex, int pageSize,string name)
        {
            WarehouseEntities con = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in con.Depart
                      where p.DepartName.IndexOf(name)!=-1
                      orderby p.Id
                      select new
                      {
                          Id = p.Id,
                          DepartNum = p.DepartNum,
                          DepartName = p.DepartName,
                          CreateTime = p.CreateTime
                      };
            //设置分页数据
            //list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            ////设置总页数
            //int rows = obj.Count();
            //list.PageCount = rows; //% pageSize == 0 ? rows / pageSize : rows / pageSize + 1;
            //return list;

            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; //rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;

            return list;
        }
        //页面加载
        public static PageList getDepart(int pageIndex, int pageSize)
        {
            WarehouseEntities con = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in con.Depart
                      orderby p.Id
                      select new
                      {
                          Id = p.Id,
                          DepartNum = p.DepartNum,
                          DepartName = p.DepartName,
                          CreateTime = p.CreateTime
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; //rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;

            return list;
        }

        //新增
        public static int Add(Depart det) {
            WarehouseEntities con = new WarehouseEntities();
            con.Depart.Add(det);
            return con.SaveChanges();
        }
        ////条件查询
        //public static List<Depart> selectByName(string name) {
        //    WarehouseEntities con = new WarehouseEntities();
        //    var obj = from p in con.Depart where p.DepartName.IndexOf(name)!=-1 select p;
        //    return obj.ToList();
        //}

    }
}
