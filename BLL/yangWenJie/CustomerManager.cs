using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;

namespace BLL
{
    public class CustomerManager
    {
        public static PageList getCustomerByName(int pageIndex, int pageSize, string name)
        {
            return CustomerService.getCustomerByName(pageIndex, pageSize, name);
        }

        public static int AddCustomer(Customer cus)
        {
            return CustomerService.AddCustomer(cus);
        }

        public static int delCustomer(int id)
        {
            return CustomerService.delCustomer(id);
        }

        public static List<Customer> CustomerSelectById(int id)
        {
            return CustomerService.CustomerSelectById(id);
        }

        //public static List<Customer> CustomerSelectById(string id)
        //{
        //    return CustomerService.CustomerSelectById(id);
        //}

        public static int upCustomerById(Customer cus, int id)
        {
            return CustomerService.upCustomerById(cus, id);
        }
    }
}
