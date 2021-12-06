using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x => x.SkillName).NotEmpty().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.SkillName).NotNull().WithMessage("Yetenek adı alanı boş bırakılamaz");
            RuleFor(x => x.SkillPercent).NotEmpty().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
            RuleFor(x => x.SkillPercent).NotNull().WithMessage("Yetenek seviyesi alanı boş bırakılamaz.");
        }
    }
}
