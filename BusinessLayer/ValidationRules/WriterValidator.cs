using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçmeyiniz.");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Soyadını Boş Geçmeyiniz.");

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanını Boş Geçmeyiniz.");
            RuleFor(x => x.WriterTitle).MinimumLength(10).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(s => s.WriterMail).NotEmpty().WithMessage("Email adresi gerekli.");
            RuleFor(s => s.WriterMail).EmailAddress().WithMessage("Geçerli bir Email Adresi Girilmelidir");

            RuleFor(f => f.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmını Boş Geçmeyiniz");

            RuleFor(x => x.WriterAbout).Must(x => x.Contains("a")).When(x => x.WriterAbout != null).WithMessage("Hakkında içeriğinde mutlaka 'a' harfi bulunmalıdır.");
        }      
    }
}
