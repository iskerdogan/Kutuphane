//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transactions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transactions()
        {
            this.Penalties = new HashSet<Penalties>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> MemberReturnDate { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Members Members { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Penalties> Penalties { get; set; }
        public virtual Staff Staff { get; set; }
    }
}