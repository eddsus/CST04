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
    
    public partial class Chocolate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chocolate()
        {
            this.Chocolate_has_Ingridients = new HashSet<Chocolate_has_Ingridients>();
            this.OrderContent_has_Chocolate = new HashSet<OrderContent_has_Chocolate>();
            this.Package_has_Chocolate = new HashSet<Package_has_Chocolate>();
            this.Rating = new HashSet<Rating>();
        }
    
        public System.Guid ID_Chocolate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public System.Guid Shape_ID { get; set; }
        public System.Guid CustomStyle_ID { get; set; }
        public string Image { get; set; }
        public System.Guid Creator_Customer_ID { get; set; }
        public System.DateTime ModifyDate { get; set; }
        public System.Guid WrappingID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual CustomStyle CustomStyle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chocolate_has_Ingridients> Chocolate_has_Ingridients { get; set; }
        public virtual Shape Shape { get; set; }
        public virtual Wrapping Wrapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderContent_has_Chocolate> OrderContent_has_Chocolate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package_has_Chocolate> Package_has_Chocolate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
