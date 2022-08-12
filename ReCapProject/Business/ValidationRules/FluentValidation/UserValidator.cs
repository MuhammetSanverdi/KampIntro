using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();            
            RuleFor(u => u.FirstName.Length).GreaterThan(2);
            RuleFor(u => u.Email).Must(EmailContains);
        }
        private bool EmailContains(string arg)
        {

            if (arg.Contains("@") && arg.Contains("."))
            {
                return true;
            }
            return false;
        }
    }
}
