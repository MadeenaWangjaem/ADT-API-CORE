using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
{
    [Table("Country", Schema = "Master")]
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public string NameAbb { get; set; }

        public Country()
        {

        }
    }
}
