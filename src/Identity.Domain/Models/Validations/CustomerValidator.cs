using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Models.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            //
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("{PropertyName}...");

            //
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName}...");
            RuleFor(x => x.Name).MinimumLength(005).WithMessage("{PropertyName}...");
            RuleFor(x => x.Name).MaximumLength(150).WithMessage("{PropertyName}...");
            RuleFor(x => x.Name).Must(BeAValidSomething).WithMessage("{PropertyName}...");
        }

        protected bool BeAValidSomething(string name)
        {
            return true;
        }
    }
}
