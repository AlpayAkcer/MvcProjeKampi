using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Hakkımızda Başlığını Boş Geçmeyiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(x => x.Description).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmını Boş Geçmeyiniz.");
        }
    }
}
