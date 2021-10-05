//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gold_Sales.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FunctionMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FunctionMenu()
        {
            this.FunctionGroupMenus = new HashSet<FunctionGroupMenu>();
            this.SecAudits = new HashSet<SecAudit>();
            this.UserLocationFunctions = new HashSet<UserLocationFunction>();
        }
    
        public int FunctionID { get; set; }
        public string FunctionName { get; set; }
        public string FunctionMenu1 { get; set; }
        public Nullable<byte> MenuLevel { get; set; }
        public Nullable<int> ParentFunctionID { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> deactivateddate { get; set; }
        public Nullable<System.DateTime> rowcreateddate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FunctionGroupMenu> FunctionGroupMenus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecAudit> SecAudits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLocationFunction> UserLocationFunctions { get; set; }
    }
}
