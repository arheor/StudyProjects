using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PR2
{
    abstract class info
    {
        protected string sort;
        protected int ves;
        protected string date;
        public info(string sort, int ves, string date)
        {
            this.sort = sort;
            this.ves = ves;
            this.date = date;
        }
        public abstract string GetInformation();
    }
}
