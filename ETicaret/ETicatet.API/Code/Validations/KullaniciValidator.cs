using ETicaret.Model;
using FluentValidation;

namespace ETicaret.Api.Code.Validations
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(k => k.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(k => k.KullaniciAdi).EmailAddress().WithMessage("Hatalı email adresi");
            RuleFor(k => k.Sifre).Length(6, 15).WithMessage("Şifre en az 6, en çok 15 karakter olabilir");
            RuleFor(k => k.Sifre).Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                                .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
