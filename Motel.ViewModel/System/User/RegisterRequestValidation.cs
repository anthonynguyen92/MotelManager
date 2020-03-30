using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motel.ViewModel.System.User
{
    public class RegisterRequestValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidation()
        {
            RuleFor(x => x.PhoneNumber).NotNull();
            RuleFor(x => x.PassWord).NotEmpty().NotNull();
            RuleFor(x => x.UserName).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.FirstName).MaximumLength(30);
            RuleFor(x => x.LastName).MaximumLength(50);


        }
    }
}
