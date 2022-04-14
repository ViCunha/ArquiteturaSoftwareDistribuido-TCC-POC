using FluentValidation;
using System;
using System.Threading;
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
            RuleFor(x => x.Name).MustAsync(BeAValidSomething).WithMessage("{PropertyName}...");
        }

        private async Task<bool> BeAValidSomething(string name, CancellationToken token)
        {
            return await Task.Factory.StartNew(() => true);
        }
    }
}
