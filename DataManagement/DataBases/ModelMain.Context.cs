﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataManagement.DataBases
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChocolateCustomizerEntities : DbContext
    {
        public ChocolateCustomizerEntities()
            : base("name=ChocolateCustomizerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Chocolate> Chocolate { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomStyle> CustomStyle { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderContent> OrderContent { get; set; }
        public virtual DbSet<OrderContent_has_Chocolate> OrderContent_has_Chocolate { get; set; }
        public virtual DbSet<OrderContent_has_Package> OrderContent_has_Package { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Shape> Shape { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Wrapping> Wrapping { get; set; }
    }
}
