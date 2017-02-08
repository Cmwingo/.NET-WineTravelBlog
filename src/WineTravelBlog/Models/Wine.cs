using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WineTravelBlog.Models
{
    [Table("Wines")]
    public class Wine
    {
        [Key]
        public int WineId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Nose { get; set; }
        public string Body { get; set; }
        public string Pallete { get; set; }
        public float Price { get; set; }
        public string Comments { get; set; }
        public int OverAllRating { get; set; }
        public int WineryId { get; set; }
        public virtual Winery Winery { get; set; }
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }

    }
}
