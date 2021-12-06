using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{

    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public int SkillPercent { get; set; }
        public int SkillValue { get; set; }
    }
}
