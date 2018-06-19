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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderContent = new HashSet<OrderContent>();
        }
    
        public string ID_Order { get; set; }
        public System.DateTime DateOfOrder { get; set; }
        public System.DateTime DateOfDelivery { get; set; }
        public System.Guid Status_ID { get; set; }
        public System.Guid Customer_ID { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent> OrderContent { get; set; }
    }
}
