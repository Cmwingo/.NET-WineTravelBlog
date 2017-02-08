using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineTravelBlog.Models
{
    [Table("Wineries")]
    public class Winery
    {
        [Key]
        public int WineryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Style { get; set; }
        public string PrimaryVarietals { get; set; }
        public string AvgPrice { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Wine> Wines { get; set; }
    }
}
