//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRSWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudyTerms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudyTerms()
        {
            this.Registrations = new HashSet<Registrations>();
            this.TAAssignments = new HashSet<TAAssignments>();
            this.TeachingAssignments = new HashSet<TeachingAssignments>();
        }
    
        public string TermID { get; set; }
        public string TermName { get; set; }
        public Nullable<System.DateTime> TermStartDate { get; set; }
        public Nullable<System.DateTime> TermEndDate { get; set; }
        public string TermYear { get; set; }
        public string TermSeason { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registrations> Registrations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TAAssignments> TAAssignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeachingAssignments> TeachingAssignments { get; set; }
    }
}