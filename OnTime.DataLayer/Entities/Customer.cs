using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTime.DataLayer.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DisplayName("姓名")]
        public string Name { get; set; }
        [DisplayName("手机号码")]
        [StringLength(maximumLength:11)]
        public string PhoneNum { get; set; }
        [DisplayName("职业")]
        public string Profession { get; set; }
        [DisplayName("股票代码")]
        public string StockCode { get; set; }
       // public int? NotifyStatus { get; set; }
       [DisplayName("创建时间")]
        public DateTime CreateTime { get; set; }   
        
        [DisplayName("来源")]
        public string Source { get; set; }//来源 mobile,pc
        [DisplayName("客户端IP")]
        public string ClientIPAddress { get; set; }  
    }
}