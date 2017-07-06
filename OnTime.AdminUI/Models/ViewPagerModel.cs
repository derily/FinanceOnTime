using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnTime.AdminUI.Models
{
    public class ViewPagerModel<T>
    {
        public int page { get; set; }
        public int records { get; set; }
        public int total { get; set; }
        public IEnumerable<T> rows { get; set; }

       
    }
}