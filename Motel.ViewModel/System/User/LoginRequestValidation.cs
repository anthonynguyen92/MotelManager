using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Motel.ViewModel.System.User
{
    public class LoginRequestValidation :AbstractValidator<LoginRequest>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.PassWord).NotNull().WithMessage("Enter your PassWord");
            RuleFor(x => x.UserName).NotNull().WithMessage("Enter your Username");
        }
    }
}
