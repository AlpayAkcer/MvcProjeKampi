using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar Adını Boş Geçmeyiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
        }
    }
}
