
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
    public abstract class CommandHandler
    {
        protected readonly List<ValidationResult> ValidationResult = new List<ValidationResult>();


        protected void AddValidationResult(string errorMessage) 
        {
            ValidationResult.Add(new ValidationResult(errorMessage));
        }


    }
}
