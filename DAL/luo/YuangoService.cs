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
                      where p.IsDelete==0
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
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsNumber(name, i))
                    {
                        obj = obj.Where(item => item.UserName.IndexOf(name) != -1);
                    }
                    else
                    {
                        int Name = int.Parse(name);
                        obj = obj.Where(item => item.UserName.IndexOf(name) != -1 || item.Id == Name);
                    }
                }
            }
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; 

            return list;
        }
        ////页面加载
        //public static PageList getDepart(int pageIndex, int pageSize)
        //{
        //    WarehouseEntities entities = new WarehouseEntities();
        //    PageList list = new PageList();
        //    var obj = from p in entities.Admin
        //              where p.IsDelete == 0
        //              orderby p.Id
        //              select new
        //              {
        //                  Id = p.Id,
        //                  UserName = p.UserName,
        //                  UserCode = p.UserCode,
        //                  RealName = p.RealName,
        //                  Email = p.Email,
        //                  Phone = p.Phone,
        //                  DepartId = p.Depart.DepartNum,
        //                  RoleId = p.Role.RoleName
        //              };
        //    list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    //设置总页数
        //    int rows = obj.Count();
        //    list.PageCount = rows; //rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;

        //    return list;
        //}

       
        public static List<Role> juesselect()
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Role where p.IsDelete == 0 select p;
            return obj.ToList();
        }
        public static List<Depart> bumenselect()
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Depart where p.IsDelete == 0 select p;
            return obj.ToList();
        }
        public static IQueryable adminid(int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Admin where p.Id == id
                      select new {
                          Id = p.Id,
                          UserName = p.UserName,
                          UserCode = p.UserCode,
                          RealName = p.RealName,
                          Email = p.Email,
                          Phone = p.Phone,
                          DepartId = p.DepartId,
                          RoleId = p.RoleId
                      };
            return obj;
        }
        public static int adminidup(string id ,string UserName, string RealName, string Email, string Phone, int DepartId , int RoleId)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Admin where p.UserCode == id select p).First();
            obj.UserName = UserName;
            obj.RealName = RealName;
            obj.Email = Email;
            obj.Phone = Phone;
            obj.DepartId = DepartId;
            obj.RoleId = RoleId;
            return entities.SaveChanges();
        }
        //删除(修改表示ID)
        public static int delDepart(int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Admin where p.Id == id select p).First();
            obj.IsDelete = 1;
            return entities.SaveChanges();
        }
        //新增
        public static int insert(string UserCode, string UserName, string RealName, string Email, string Phone, int DepartId, int RoleId)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = new  Admin();
            obj.UserName = UserName;
            obj.UserCode = UserCode;
            obj.RealName = RealName;
            obj.Email = Email;
            obj.Phone = Phone;
            obj.DepartId = DepartId;
            obj.RoleId = RoleId;
            obj.CreateTime = DateTime.Now;
            obj.Password = "123456";
            obj.IsDelete = 0;
            obj.LoginCount = 1;
            entities.Admin.Add(obj);
            return entities.SaveChanges();
        }
    }
}
 
   

