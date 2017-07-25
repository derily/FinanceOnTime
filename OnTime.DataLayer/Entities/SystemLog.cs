using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.DataLayer.Entities
{
   public class SystemLog
    {
        public Guid Id { get; set; }
        public string OperateType { get; set; }
        public string ModuleName { get; set; }
        public string Details { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
