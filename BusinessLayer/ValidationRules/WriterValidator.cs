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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar Adını Boş Geçmeyiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("En Az 3 Karakter Girilmelidir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadını Boş Geçmeyiniz.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Yazar Ünvanını Boş Geçmeyiniz.");
            RuleFor(x => x.Title).MinimumLength(10).WithMessage("En Az 3 Karakter Girilmelidir.");

            RuleFor(s => s.Mail).NotEmpty().WithMessage("Email adresi gerekli.");
            RuleFor(s => s.Mail).EmailAddress().WithMessage("Geçerli bir Email Adresi Girilmelidir");

            //https://www.c-sharpcorner.com/article/fluent-validation-in-asp-net-mvc/
            //https://docs.fluentvalidation.net/en/latest/built-in-validators.html
            //https://soshace.com/fluent-validation-in-asp-net-mvc/

            //RuleFor(x => x.WriterAbout).Must(WriterAboutContains).WithMessage("Yazar Hakkında kısmı mutlaka a harfi bulunmalıdır.");

            //RuleFor(m => m.WriterAbout).NotEmpty().Unless(m => !string.IsNullOrEmpty(m.WriterAbout)).WithMessage("Yazar Hakkında Kısmını Boş Geçmeyiniz");            

            //RuleFor(f => f.WriterAbout).Must((f, t) => f.WriterAbout.Contains("a")).WithMessage("Must start with ADM");

            RuleFor(f => f.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmını Boş Geçmeyiniz");

            RuleFor(x => x.WriterAbout).Must(x => x.Contains("a")).When(x => x.WriterAbout != null).WithMessage("Hakkında içeriğinde mutlaka 'a' harfi bulunmalıdır.");

        }

        //private bool WriterAboutContains(string str)
        //{
        //    return str.Contains("a");
        //}

    }
}
