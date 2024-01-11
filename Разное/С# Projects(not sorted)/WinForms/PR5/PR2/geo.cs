using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PR2
{
    class geo:info
    {
        string country;
        public string country_name
        {
            get { return country; }
            set { country = value; }
        }
        public geo(string sort, int ves, string date, string country)
            : base(sort,ves,date)
        {
            this.country = country;
        }
        public override string GetInformation()
        {
            return "Сорт: " + sort + "; Объем: " + ves + " тонн; Дата сбора: " + date + ";" + System.Environment.NewLine + "Страна: " + country + System.Environment.NewLine;
        }
    }
}
