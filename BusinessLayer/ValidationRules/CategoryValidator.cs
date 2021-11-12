using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adını Boş Geçmeyiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı Boş Geçmeyiniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapmalısınız");
            RuleFor(x => x.Name).MaximumLength(25).WithMessage("En fazla 25 Karakter Girişi Yapmalısınız");
        }
    }
}
