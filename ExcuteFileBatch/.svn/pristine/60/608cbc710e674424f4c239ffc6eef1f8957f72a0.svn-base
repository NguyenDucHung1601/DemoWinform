using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationDLL {
    public class ValidateResult {
        private readonly IList<ValidationFailure> errors;

        public ValidateResult() {
            this.errors = new List<ValidationFailure>();
        }

        public ValidateResult(IEnumerable<ValidationFailure> failures) {
            errors = failures.Where(failure => failure != null).ToList();
        }

        public virtual bool IsValid => Errors.Count == 0;
        public IList<ValidationFailure> Errors => errors;
        public string[] RuleSetsExecuted { get; internal set; }

        /// <summary>
        /// Generates a string representation of the error messages separated by new lines.
        /// </summary>
        public override string ToString() {
            return ToString(Environment.NewLine);
        }

        /// <summary>
		/// Generates a string representation of the error messages separated by the specified character.
		/// </summary>
        public string ToString(string separator) {
            return string.Join(separator, errors.Select(failure => failure.ErrorMessage));
        }

    }
}