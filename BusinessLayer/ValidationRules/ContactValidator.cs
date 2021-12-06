using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçmeyiniz.");
            RuleFor(x => x.UserMail).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Başlığını Boş Geçmeyiniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girilmelidir.");
        }
    }
}
