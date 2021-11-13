using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterId { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(70)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(150)]
        public string Picture { get; set; }

        [StringLength(200)]
        public string Mail { get; set; }

        [StringLength(200)]
        public string Password { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
