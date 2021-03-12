using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidationDLL {
    public interface IValidationRule {
        IEnumerable<IPropertyValidator> Validators { get; }
        string[] RuleSets { get; set; }

        IEnumerable<ValidationFailure> Validate(IValidationContext context);
        Task<IEnumerable<ValidationFailure>> ValidateAsync(IValidationContext context, CancellationToken cancellation);

    }
}