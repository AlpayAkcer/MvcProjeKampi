using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Summary { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
