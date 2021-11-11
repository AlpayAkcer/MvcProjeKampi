using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(70)]
        public string UserName { get; set; }
        [StringLength(70)]
        public string Surname { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(500)]
        public string Messge { get; set; }
        public bool IsActive { get; set; }
    }
}
