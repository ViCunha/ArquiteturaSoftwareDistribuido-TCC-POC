
using FluentValidation.Results;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Domain.Models.Events
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public Task<Unit> Handle(ValidationResult request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
