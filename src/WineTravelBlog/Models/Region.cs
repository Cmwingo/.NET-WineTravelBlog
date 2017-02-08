using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineTravelBlog.Models
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string GrowingSeason { get; set; }
        public float AvgRainfall { get; set; }
        public virtual ICollection<Winery> Wineries { get; set; }
        public virtual ICollection<Wine> Wines { get; set; }
    }
}
