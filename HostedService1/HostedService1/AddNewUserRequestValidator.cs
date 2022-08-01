using FluentValidation;

namespace HostedService1
{
    public class AddNewUserRequestValidator: AbstractValidator<AddNewUserRequest>
    {
        public AddNewUserRequestValidator()
        {
            RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("必須是合法郵箱").Must(x => x.EndsWith("@gmail.com") || x.EndsWith("@edu.com.tw")).WithMessage("Email只能是gmail或教育信箱");
            RuleFor(x => x.UserName).NotNull().Length(3, 10).WithMessage("密碼要界於3~10");
            RuleFor(x => x.Password).Equal(x => x.Password2).WithMessage("密碼要一致");
        }
    }
}
