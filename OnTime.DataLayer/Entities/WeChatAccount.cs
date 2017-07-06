using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime.DataLayer.Entities
{
    public class WeChatAccount
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string AccountId { get; set; }
        public string NickName { get; set; }

        public string BarCode { get; set; }
        public bool Valid { get; set; }
    }
}
