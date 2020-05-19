using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL
{
    public class CustomerService
    {
        public static PageList getCustomerByName(int pageIndex, int pageSize, string name)
        {
            WarehouseEntities con = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in con.Customer
                      where p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          CustomerNum = p.CustomerNum,
                          CustomerName = p.CustomerName,
                          Phone = p.Phone,
                          Fax = p.Fax,
                          CreateTime = p.CreateTime
                      };
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsNumber(name, i))
                    {
                        obj = obj.Where(item => item.CustomerName.IndexOf(name) != -1);
                    }
                    else
                    {
                        string Name = name;
                        obj = obj.Where(item => item.CustomerName.IndexOf(name) != -1 || item.CustomerNum == Name);
                    }
                }
            }
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            int rows = obj.Count();
            list.PageCount = rows;
            return list;
        }
        //新增
        public static int AddCustomer(Customer cus)
        {
            WarehouseEntities con = new WarehouseEntities();
            con.Customer.Add(cus);
            return con.SaveChanges();
        }

        //删除(修改表示ID)
        public static int delCustomer(int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Customer where p.Id == id select p).First();
            obj.IsDelete = 1;
            return con.SaveChanges();
        }

        //根据ID查询
        public static List<Customer> CustomerSelectById(int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = from p in con.Customer where p.Id == id select p;
            return obj.ToList();
        }


        //根据id修改
        public static int upCustomerById(Customer cus, int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Customer where p.Id == id select p).First();
            obj.CustomerName = cus.CustomerName;
            obj.Contacts = cus.Contacts;
            obj.CreateTime = DateTime.Now;
            obj.Phone = cus.Phone;
            obj.Fax = cus.Fax;
            obj.Email = cus.Email;
            obj.Address = cus.Address;
            obj.CreateUser = cus.CreateUser;
            obj.CreateTime = cus.CreateTime;
            obj.IsDelete = cus.IsDelete;
            obj.Remark = cus.Remark;
            return con.SaveChanges();
        }
    }
}
