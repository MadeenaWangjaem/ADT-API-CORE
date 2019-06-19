using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
{
    [Table("Organization", Schema = "Profile")]
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public int? GroupID { get; set; }
        public int? TypeID { get; set; }
        public string OfficePhone { get; set; }
        public string FAXNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string TaxPayerID { get; set; }
        public string BillingAddress { get; set; }
        public string BillingProvince { get; set; }
        public string BillingPostCode { get; set; }
        public string BillingCountry { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingProvince { get; set; }
        public string ShippingPostCode { get; set; }
        public int? ShippingCountry { get; set; }
        public string Description { get; set; }
        public bool? OrgaizationActive { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string ParentRefCode { get; set; }
        public string ChildRefCode { get; set; }


        public Organization()
        {
        }
    }
}
