﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
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


        public virtual Contact Contact { get; set; }
        public virtual Organization Organization { get; set; }
       

        public User()
        {
        }
        public User(String UserName)
        {
            this.UserName = UserName;
        }
        public User(String UserName,String Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }
      
    }
}
