﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFirstModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinanceOnTimeEntities : DbContext
    {
        public FinanceOnTimeEntities()
            : base("name=FinanceOnTimeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
           // modelBuilder.Entity<ArticleSet>().Map(p=>p.)
        }
    
        public virtual DbSet<ArticleSet> ArticleSet { get; set; }
        public virtual DbSet<DictionarySet> DictionarySet { get; set; }
        public virtual DbSet<EventSet> EventSet { get; set; }
        public virtual DbSet<GoodsSet> GoodsSet { get; set; }
        public virtual DbSet<IndexDataSet> IndexDataSet { get; set; }
        public virtual DbSet<IndexSet> IndexSet { get; set; }
        public virtual DbSet<MessageSet> MessageSet { get; set; }
    }
}
