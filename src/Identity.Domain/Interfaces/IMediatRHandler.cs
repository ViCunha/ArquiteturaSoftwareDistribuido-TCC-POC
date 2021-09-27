using Identity.Domain.Models.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces
{
    public interface IMediatRHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<IEnumerable<ValidationResult>> SendCommand<T>(T @command) where T : Command;
    }
}
