//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Customer_has_Address
    {
        public System.Guid Customer_ID { get; set; }
        public System.Guid Address_ID { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
    }
}