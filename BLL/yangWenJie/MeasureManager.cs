using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models1;
using DAL;

namespace BLL
{
    public class MeasureManager
    {
        public static PageList getMeasureByName(int pageIndex, int pageSize, string name)
        {
            return MeasureService.getMeasureByName(pageIndex, pageSize, name);
        }
        public static int delMeasure(int id)
        {
            return MeasureService.delMeasure(id);
        }

        public static int AddMeasure(Measure mes)
        {
            return MeasureService.AddMeasure(mes);
        }

        public static List<Measure> mesSelectById(int id)
        {
            return MeasureService.mesSelectById(id);
        }

        public static int upMeasureById(Measure mes, int id)
        {
            return MeasureService.upMeasureById(mes, id);
        }


    }
}
