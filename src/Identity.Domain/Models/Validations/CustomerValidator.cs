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
            IdPropertyValidations();
            NamePropertyValidations();
        }

        private IEnumerable<IRuleBuilder<Customer, Guid>> IdPropertyValidations()
        {
            yield return RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("");
        }

        private IEnumerable<IRuleBuilder<Customer, String>> NamePropertyValidations()
        {
            yield return RuleFor(x => x.Name).NotNull().WithMessage("");
            yield return RuleFor(x => x.Name).MinimumLength(005).WithMessage("");
            yield return RuleFor(x => x.Name).MaximumLength(150).WithMessage("");
        }

    }
}
