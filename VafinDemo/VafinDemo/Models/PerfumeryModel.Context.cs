﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VafinDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PerfumeryEntities : DbContext
    {
        private static PerfumeryEntities _context;
        public PerfumeryEntities()
            : base("name=PerfumeryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Order_Product> Order_Product { get; set; }
        public virtual DbSet<PointOfIssue> PointOfIssue { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<USer> USer { get; set; }
        public static PerfumeryEntities GetContext()
        {
            if (_context == null)
                _context = new PerfumeryEntities();
            return _context;
        }
    }
}
