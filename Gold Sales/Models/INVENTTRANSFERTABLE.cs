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
    
    public partial class INVENTTRANSFERTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVENTTRANSFERTABLE()
        {
            this.INVENTTRANSFERLINEs = new HashSet<INVENTTRANSFERLINE>();
        }
    
        public string TRANSFERID { get; set; }
        public Nullable<long> TRANSFERIDNUM { get; set; }
        public string TRANSFERIDRETURN { get; set; }
        public string INVENTLOCATIONIDFROM { get; set; }
        public string INVENTLOCATIONIDTO { get; set; }
        public string INVENTLOCATIONIDTRANSIT { get; set; }
        public Nullable<System.DateTime> SHIPDATE { get; set; }
        public Nullable<System.DateTime> RECEIVEDATE { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<System.DateTime> APPROVEDDATE { get; set; }
        public Nullable<System.DateTime> CLOSUREDATE { get; set; }
        public Nullable<int> TRANSFERSTATUS { get; set; }
        public Nullable<int> TotalLines { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public string MachineIP { get; set; }
        public string Machineuser { get; set; }
        public string MachineName { get; set; }
        public Nullable<int> userid { get; set; }
        public string MachineIPupdated { get; set; }
        public string MachineUserUpdated { get; set; }
        public string MachineNameUpdated { get; set; }
        public Nullable<int> useridUpdated { get; set; }
        public Nullable<System.DateTime> rowcreateddate { get; set; }
        public Nullable<int> iabc { get; set; }
        public Nullable<int> idef { get; set; }
        public Nullable<int> ighi { get; set; }
        public Nullable<int> ijkl { get; set; }
        public string Sabc { get; set; }
        public string Sdef { get; set; }
        public string Sghi { get; set; }
        public string Sjkl { get; set; }
        public Nullable<System.DateTime> Dabc { get; set; }
        public Nullable<System.DateTime> Ddef { get; set; }
        public Nullable<System.DateTime> Dghi { get; set; }
        public Nullable<System.DateTime> Djkl { get; set; }
        public Nullable<decimal> DECabc { get; set; }
        public Nullable<decimal> DECdef { get; set; }
        public Nullable<decimal> DECghi { get; set; }
        public Nullable<decimal> DECjkl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVENTTRANSFERLINE> INVENTTRANSFERLINEs { get; set; }
    }
}
