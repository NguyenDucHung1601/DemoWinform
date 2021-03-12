using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationDLL {
    public class ValidationFailure {
		private ValidationFailure() {
		}

		/// Creates a new validation failure.
		public ValidationFailure(string propertyName, string errorMessage) : this(propertyName, errorMessage, null) {
		}

		/// Creates a new ValidationFailure.
		public ValidationFailure(string propertyName, string errorMessage, object attemptedValue) {
			PropertyName = propertyName;
			ErrorMessage = errorMessage;
			AttemptedValue = attemptedValue;
		}

		/// The name of the property.
		public string PropertyName { get; set; }

		/// The error message
		public string ErrorMessage { get; set; }

		/// The property value that caused the failure.
		public object AttemptedValue { get; set; }

		/// Gets or sets the error code.
		public string ErrorCode { get; set; }

        /// Creates a textual representation of the failure.
        public override string ToString() {
			return ErrorMessage;
		}
	}
}