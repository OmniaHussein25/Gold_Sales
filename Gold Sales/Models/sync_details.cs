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
    
    public partial class sync_details
    {
        public long syn_id { get; set; }
        public long sync_details_linenum { get; set; }
        public Nullable<int> InvID { get; set; }
        public string CompanyID { get; set; }
        public string BranchID { get; set; }
        public System.DateTime Invdate { get; set; }
        public string InvType { get; set; }
        public string InvCurr { get; set; }
        public Nullable<decimal> Inv_CurrRate { get; set; }
        public Nullable<decimal> Inv_CurrAmount { get; set; }
        public Nullable<decimal> Inv_LocalAmount { get; set; }
        public Nullable<decimal> Inv_Qty { get; set; }
        public Nullable<int> Inv_Lines { get; set; }
        public string CustomerID { get; set; }
        public string Custname { get; set; }
        public string Custname_ENG { get; set; }
        public string CustCategory { get; set; }
        public string Cust_TaxID { get; set; }
        public string Cust_TaxType { get; set; }
        public string Cust_TaxName { get; set; }
        public string Cust_CountryApr { get; set; }
        public string Cust_Countryname { get; set; }
        public string Cust_City { get; set; }
        public string Cust_Street { get; set; }
        public string Cust_Building { get; set; }
        public string Cust_PostNo { get; set; }
        public int linenum { get; set; }
        public string ItemID { get; set; }
        public string itemname { get; set; }
        public string itemname_ENG { get; set; }
        public string ItemTaxCode { get; set; }
        public string TaxCodeType { get; set; }
        public string ItemTaxUnit { get; set; }
        public Nullable<decimal> itemqty { get; set; }
        public Nullable<decimal> itemprice { get; set; }
        public Nullable<decimal> itemDiscPrc { get; set; }
        public Nullable<decimal> itemAmount { get; set; }
        public Nullable<decimal> itemTaxAmount { get; set; }
        public string PortalInvID { get; set; }
        public string PortalInvlink { get; set; }
        public Nullable<int> Inv_portal_status { get; set; }
        public Nullable<int> IsReuploaded { get; set; }
        public Nullable<System.DateTime> Reuploaddate { get; set; }
    }
}
