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
    
    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            this.OrderContent_has_Package = new HashSet<OrderContent_has_Package>();
            this.Package_has_Chocolate = new HashSet<Package_has_Chocolate>();
            this.Rating = new HashSet<Rating>();
        }
    
        public System.Guid ID_Package { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public string Wrapping { get; set; }
        public bool Availability { get; set; }
        public System.Guid Customer_ID { get; set; }
        public string Image { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public System.Guid WrappingID { get; set; }
    
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent_has_Package> OrderContent_has_Package { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_has_Chocolate> Package_has_Chocolate { get; set; }
        public virtual Wrapping Wrapping1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
