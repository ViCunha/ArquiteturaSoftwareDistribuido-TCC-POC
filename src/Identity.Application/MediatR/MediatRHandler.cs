using Identity.Domain.Interfaces;
using Identity.Domain.Models.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.MediatR
{
    public class MediatRHandler : IMediatRHandler
    {
        private readonly IMediator _mediator;

        public MediatRHandler(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task PublishEventAsync<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }

        public async Task<IEnumerable<ValidationResult>> SendCommandAsync<T>(T @command) where T : Command
        {
            return await _mediator.Send(@command); 
        }
    }

}
