//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataManager.DataBases
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderContent_has_Chocolate
    {
        public System.Guid OrderContent_ID { get; set; }
        public System.Guid Chocolate_ID { get; set; }
        public int Amount { get; set; }
    
        public virtual Chocolate Chocolate { get; set; }
        public virtual OrderContent OrderContent { get; set; }
    }
}
