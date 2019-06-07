using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
{
    [Table("Contact", Schema = "Profile")]
    public class Contact
    {
        public int ContactID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public int OrganizationID { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string OfficePhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string MailingAddress { get; set; }
        public string MailingProvince { get; set; }
        public string MailingPostCode { get; set; }
        public string MailingCountry { get; set; }
        public string OtherAddress { get; set; }
        public string OtherPOBox { get; set; }
        public string OtherCity { get; set; }
        public string OtherState { get; set; }
        public string OtherPostCode { get; set; }
        public Nullable<int> OtherCountry { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> rowguid { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Organization Organization { get; set; }

        public Contact()
        {
        }
    }
}
