using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidationDLL {

	public interface IValidator<in T> : IValidator {
		/// <summary>
		/// Validates the specified instance.
		/// </summary>
		/// <param name="instance">The instance to validate</param>
		/// <returns>A ValidationResult object containing any validation failures.</returns>
		ValidationResult Validate(T instance);

		/// <summary>
		/// Validate the specified instance asynchronously
		/// </summary>
		/// <param name="instance">The instance to validate</param>
		/// <param name="cancellation"></param>
		/// <returns>A ValidationResult object containing any validation failures.</returns>
		Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellation = new CancellationToken());

		/// Sets the cascade mode for all rules within this validator.
		CascadeMode CascadeMode { get; set; }
	}
	public interface IValidator {
        //ValidateResult ValidateResult { get; set; }

        ValidationResult Validate(IValidationContext context);
        Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = new CancellationToken());
        IValidatorDescriptor CreateDescriptor();
        bool CanValidateInstancesOfType(Type type);

    }
}