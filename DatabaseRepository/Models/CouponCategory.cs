//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseRepository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CouponCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CouponCategory()
        {
            this.GiveawaysAvailable = new HashSet<GiveawaysAvailable>();
        }
    
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiveawaysAvailable> GiveawaysAvailable { get; set; }
    }
}