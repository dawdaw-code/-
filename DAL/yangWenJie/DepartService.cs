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
        //显示全部
        //public static List<Depart> selectAll()
        //{
        //    WarehouseEntities con = new WarehouseEntities();
        //    var obj = from p in con.Depart select p;
        //    return obj.ToList();
        //}
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
            //设置分页数据
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;


            return list;
        }

        //新增
        public static int Add(Depart det) {
            WarehouseEntities con = new WarehouseEntities();
            con.Depart.Add(det);
            return con.SaveChanges();
        }
        //条件查询
        public static Depart selectByName(string name) {
            WarehouseEntities con = new WarehouseEntities();
            var obj = from p in con.Depart where p.DepartName == name select p;
            return obj.First();
        }

    }
}
