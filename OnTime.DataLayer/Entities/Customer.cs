using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnTime.DataLayer.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [StringLength(maximumLength:11)]
        public string PhoneNum { get; set; }
        public string Profession { get; set; }
        public string StockCode { get; set; }
        public DateTime CreateTime { get; set; }      
    }
}