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
    
    public partial class Rating
    {
        public System.Guid ID_Rating { get; set; }
        public int Value { get; set; }
        public System.DateTime Date { get; set; }
        public System.Guid Package_ID { get; set; }
        public System.Guid Chocolate_ID { get; set; }
        public string Comment { get; set; }
        public bool Published { get; set; }
        public System.Guid Customer_ID { get; set; }
    
        public virtual Chocolate Chocolate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Package Package { get; set; }
    }
}
