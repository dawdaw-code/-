using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;

namespace DAL
{
    public class MeasureService
    {
        public static PageList getMeasureByName(int pageIndex, int pageSize, string name)
        {
            WarehouseEntities con = new WarehouseEntities();
            PageList list = new PageList();
            var obj = from p in con.Measure
                      where p.IsDelete == 0
                      orderby p.Id
                      select new
                      {
                          Id = p.Id,
                          MeasureNum = p.MeasureNum,
                          MeasureName = p.MeasureName

                      };
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!Char.IsNumber(name, i))
                    {
                        obj = obj.Where(item => item.MeasureName.IndexOf(name) != -1);
                    }
                    else
                    {
                        string Name = name;
                        obj = obj.Where(item => item.MeasureName.IndexOf(name) != -1 || item.MeasureNum == Name);
                    }
                }
            }
            list.DataList = obj.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            int rows = obj.Count();
            list.PageCount = rows;
            return list;
        }


        //删除(修改表示ID)
        public static int delMeasure(int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Measure where p.Id == id select p).First();
            obj.IsDelete = 1;
            return con.SaveChanges();
        }

        //新增
        public static int AddMeasure(Measure mes)
        {
            WarehouseEntities con = new WarehouseEntities();
            con.Measure.Add(mes);
            return con.SaveChanges();
        }

        //根据ID查询
        public static List<Measure> mesSelectById(int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = from p in con.Measure where p.Id == id select p;
            return obj.ToList();
        }
        //根据id修改
        public static int upMeasureById(Measure mes, int id)
        {
            WarehouseEntities con = new WarehouseEntities();
            var obj = (from p in con.Measure where p.Id == id select p).First();
            obj.MeasureName = mes.MeasureName;
            obj.CreateTime = DateTime.Now;
            return con.SaveChanges();
        }
    }
}
