using FluentValidation.Results;
using Identity.Domain.Models.Events;

using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IMediatRHandler
    {
        Task PublishEventAsync<T>(T @event) where T : Event;

        Task<ValidationResult> SendCommandAsync<T>(T @command) where T : Command;
    }
}
