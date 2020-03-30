using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Motel.ViewModel.System.User
{
    public class RegisterValidation : AbstractValidator<RegisterRequest>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(50);
            RuleFor(x => x.LastName).MaximumLength(50);
            RuleFor(x => x.PassWord).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
        }
    }
}
