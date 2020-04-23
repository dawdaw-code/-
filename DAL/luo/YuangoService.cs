using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL.luo
{
    public class YuangoService
    {
        public static IQueryable AdminSelect()
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Admin
                      where p.IsDelete == 0
                      select new
                      {
                          UserName = p.UserName,
                          UserCode=p.UserCode,
                          RealName = p.RealName,
                          Email = p.Email,
                          Phone = p.Phone,
                          DepartId = p.Depart.DepartNum,
                          RoleId = p.Role.RoleName
        };
            return obj;
        }
        //根据用户名名查询
        public static PageList getDepartByName(int pageIndex, int pageSize, string name)
        {
            WarehouseEntities entities = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in entities.Admin
                      where p.UserName.IndexOf(name) != -1 && p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          UserName = p.UserName,
                          UserCode = p.UserCode,
                          RealName = p.RealName,
                          Email = p.Email,
                          Phone = p.Phone,
                          DepartId = p.Depart.DepartNum,
                          RoleId = p.Role.RoleName
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; 

            return list;
        }
        //页面加载
        public static PageList getDepart(int pageIndex, int pageSize)
        {
            WarehouseEntities entities = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in entities.Admin
                      where p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          Id = p.Id,
                          UserName = p.UserName,
                          UserCode = p.UserCode,
                          RealName = p.RealName,
                          Email = p.Email,
                          Phone = p.Phone,
                          DepartId = p.Depart.DepartNum,
                          RoleId = p.Role.RoleName
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; //rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;

            return list;
        }

        //新增
        public static int Add(Depart det)
        {
            WarehouseEntities con = new WarehouseEntities();
            con.Depart.Add(det);
            return con.SaveChanges();
        }

        //删除(修改表示ID)
        public static int delDepart(int Id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Admin where p.Id == Id select p).First();
            obj.IsDelete = 1;
            return entities.SaveChanges();
        }

        //根据id修改
        public static int upDepartById(string DepartName, int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Depart where p.Id == id select p).First();
            obj.DepartName = DepartName;
            obj.CreateTime = DateTime.Now; ;
            return con.SaveChanges();
        }
    }
}
 
   

