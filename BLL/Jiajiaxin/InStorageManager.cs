using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL.Jiajiaxin;
namespace BLL.Jiajiaxin
{
    public class InStorageManager
    {
        public static int AddInStorage(InStorage ie)
        {
            return InStorageService.AddInStorage(ie);
        }















        }
    }
