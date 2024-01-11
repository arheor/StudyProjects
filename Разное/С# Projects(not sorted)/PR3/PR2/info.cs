using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PR2
{
    class info
    {
        string sort;
        int ves;
        string date;
        public info(string sort, int ves, string date)
        {
            this.sort = sort;
            this.ves = ves;
            this.date = date;
        }
        public virtual string GetInformation()
        {
            string info;
            return info  = "Сорт: " + this.sort + "; Объем: " + this.ves + " тонн; Дата сбора: " + this.date + ";" + System.Environment.NewLine;
        }
    }
}
