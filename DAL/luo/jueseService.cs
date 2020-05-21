using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
namespace DAL.luo
{
    public class jueseService
    {
        //根据用户名名查询
        public static PageList getRoleName(int pageIndex, int pageSize, string name)
        {
            WarehouseEntities entities = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in entities.Role
                      where p.RoleName.IndexOf(name) != -1 && p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          Id=p.Id,
                          RoleName = p.RoleName,
                          RoleNum = p.RoleNum,
                          CreateTime = p.CreateTime,
                          Remark = p.Remark,
                         
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows;

            return list;
        }
        //页面加载
        public static PageList getRolePower(int pageIndex, int pageSize)
        {
            WarehouseEntities entities = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in entities.Role
                      where p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          Id = p.Id,
                          RoleName = p.RoleName,
                          RoleNum = p.RoleNum,
                          CreateTime = p.CreateTime,
                          Remark = p.Remark,
                      };
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //设置总页数
            int rows = obj.Count();
            list.PageCount = rows; //rows % pageSize == 0 ? rows / pageSize : rows / pageSize + 1;

            return list;
        }
        //删除(修改表示ID)
        public static int delRole( int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Role where p.Id == id select p).First();
            obj.IsDelete = 1;
            return entities.SaveChanges();
        }
        public static IQueryable Role(int id)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = from p in entities.Role
                      where p.Id == id
                      select new
                      {
                          Id = p.Id,
                          RoleNum = p.RoleNum,
                          RoleName = p.RoleName,
                          Remark = p.Remark
                      };
            return obj;
        }
        //修改
        public static int update(string id, string RoleName, string Remark)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = (from p in entities.Role where p.RoleNum == id select p).First();
            obj.RoleName = RoleName;
            obj.Remark = Remark;
            return entities.SaveChanges();
        }
        //新增
        public static int insert(string RoleNum, string RoleName, string Remark)
        {
            WarehouseEntities entities = new WarehouseEntities();
            var obj = new Role();
            obj.RoleNum = RoleNum;
            obj.RoleName = RoleName;
            obj.Remark = Remark;
            obj.CreateTime = DateTime.Now;
            obj.IsDelete = 0;
            entities.Role.Add(obj);
            return entities.SaveChanges();
        }
    }
}
