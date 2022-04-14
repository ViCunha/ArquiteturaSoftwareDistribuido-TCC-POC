using FluentValidation.Results;
using Identity.Domain.Interfaces;
using Identity.Domain.Models.Events;
using MediatR;
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

        public async Task<ValidationResult> SendCommandAsync<T>(T @command) where T : Command
        {
            return await _mediator.Send(@command);
        }
    }

}
