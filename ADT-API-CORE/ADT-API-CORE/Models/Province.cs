using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ADT_API_CORE.Models
{
    [Table("Province", Schema = "Master")]
    public class Province
    {
        public int ProvinceID { get; set; }
        public string Name { get; set; }
        public string NameAbb { get; set; }
        public int CountryID { get; set; }
        public int RegionID { get; set; }

        public virtual Country Country { get; set; }
        public virtual Region Region { get; set; }
        public Province()
        {

        }
    }
}
