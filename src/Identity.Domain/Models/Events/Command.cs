
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Domain.Models.Events
{
    public abstract class Command : Message, IValidatableObject, IRequest<IEnumerable<ValidationResult>>
    {
        public Task<Unit> Handle(ValidationResult request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
