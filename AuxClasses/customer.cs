//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GTS.AuxClasses
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            this.phone_number = new HashSet<phone_number>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public Nullable<int> phone_type_id { get; set; }
        public Nullable<int> ate_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<bool> has_debt { get; set; }
        public Nullable<bool> has_intercity { get; set; }
        public Nullable<int> phone_number_id { get; set; }
    
        public virtual ate ate { get; set; }
        public virtual category category { get; set; }
        public virtual phone_type phone_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phone_number> phone_number { get; set; }
    }
}
