using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL.Jiajiaxin
{
    public class InStorageService
    {
        public static int AddInStorage(InStorage ie)
        {
            WarehouseEntities entities = new WarehouseEntities();
            entities.InStorage.Add(ie);
            return entities.SaveChanges();
        }
        
















    }
}
