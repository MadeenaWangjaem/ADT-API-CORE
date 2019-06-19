using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
{
    public class ResponJson
    {
        public bool status;
        public String message;

        public virtual User user { get; set; }



        public ResponJson()
        {

        }
    }
}
