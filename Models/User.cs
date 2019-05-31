using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT.API.CORE.Models
{
    [Table("User", Schema = "Login")]
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizationID { get; set; }
        public int ContactID { get; set; }
        public bool Active { get; set; }
        public bool Admin { get; set; }
        public bool SystemAdmin { get; set; }
        public bool Buyer { get; set; }
        public bool Seller { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Organization Organization { get; set; }

        public User()
        {
        }
    }
}
