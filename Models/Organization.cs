using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.API.CORE.Models
{
    [Table("Organization", Schema = "Profile")]
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public Nullable<int> GroupID { get; set; }
        public string OfficePhone { get; set; }
        public string FAXNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string BillingAddress { get; set; }
        public string BillingPOBox { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostCode { get; set; }
        public Nullable<int> BillingCountry { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPOBox { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostCode { get; set; }
        public Nullable<int> ShippingCountry { get; set; }
        public string Description { get; set; }
        public Nullable<bool> OrgaizationActive { get; set; }
        public Nullable<System.Guid> rowguid { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<int> TypeID { get; set; }
        public string ParentRefCode { get; set; }
        public string ChildRefCode { get; set; }
        public string TaxPayerID { get; set; }

        public Organization()
        {
        }
    }
}
