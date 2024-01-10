using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PR2
{
    interface information
    {
        string GetInformation2();
    }
    class geo1 : info,information
    {
        public geo1(string sort, int ves, string date, string country)
            : base(sort, ves, date)
        {

        }
        public string GetInformation2()
        {
            return base.GetInformation();
        }
    }
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
            this.country_name = country;
        }
        
        public override string GetInformation()
        {
            string info = base.GetInformation() + "Страна: " + this.country + System.Environment.NewLine;
            return info;
        }

    }
}
