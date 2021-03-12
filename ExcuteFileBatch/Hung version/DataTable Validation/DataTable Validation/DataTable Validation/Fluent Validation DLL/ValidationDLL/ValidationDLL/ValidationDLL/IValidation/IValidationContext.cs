using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValidationDLL {
    public interface ICommonContext {

		/// The object currently being validated.
		object InstanceToValidate { get; }

		/// The value of the property being validated.
		object PropertyValue { get; }

		/// Parent validation context.
		ICommonContext ParentContext { get; }
	}

    public interface IValidationContext : ICommonContext{

		/// Additional data associated with the validation request.
		IDictionary<string, object> RootContextData { get; }

		/// Selector
		IValidatorSelector Selector { get; }

		/// Whether this is a child context
		bool IsChildContext { get; }

		/// Whether this is a child collection context.
		bool IsChildCollectionContext { get; }

		/// Property chain
		PropertyChain PropertyChain { get; }
	}

    public class ValidationContext<T> : IValidationContext {
		private ICommonContext _parentContext;

		/// Creates a new validation context
		/// <param name="instanceToValidate"></param>
		public ValidationContext(T instanceToValidate) : this(instanceToValidate, new PropertyChain(), ValidatorOptions.Global.ValidatorSelectors.DefaultValidatorSelectorFactory()) {
		}

		/// Creates a new validation context with a custom property chain and selector
		/// <param name="instanceToValidate"></param>
		/// <param name="propertyChain"></param>
		/// <param name="validatorSelector"></param>
		public ValidationContext(T instanceToValidate, PropertyChain propertyChain, IValidatorSelector validatorSelector) {
			PropertyChain = new PropertyChain(propertyChain);
			InstanceToValidate = instanceToValidate;
			Selector = validatorSelector;
		}

		/// Additional data associated with the validation request.
		/// </summary>
		public IDictionary<string, object> RootContextData { get; private protected set; } = new Dictionary<string, object>();

		/// The object to validate
		/// </summary>
		public T InstanceToValidate { get; private set; }

		/// Selector
		public IValidatorSelector Selector { get; private set; }

		public PropertyChain PropertyChain { get; private set; }
		
		/// Whether this is a child context
		public virtual bool IsChildContext { get; internal set; }

		/// Whether this is a child collection context.
		public virtual bool IsChildCollectionContext { get; internal set; }
		
		// root level context doesn't know about properties.
		object ICommonContext.PropertyValue => null;

		// This is the root context so it doesn't have a parent.
		// Explicit implementation so it's not exposed necessarily.
		ICommonContext ICommonContext.ParentContext => _parentContext;

		/// Object being validated
		object ICommonContext.InstanceToValidate => InstanceToValidate;

		/// Whether the root validator should throw an exception when validation fails.
		/// Defaults to false.
		public bool ThrowOnFailures { get; internal set; }


		/// Gets or creates generic validation context from non-generic validation context.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="NotSupportedException"></exception>
		public static ValidationContext<T> GetFromNonGenericContext(IValidationContext context) {
			if (context == null) throw new ArgumentNullException(nameof(context));

			// Already of the correct type.
			if (context is ValidationContext<T> c) {
				return c;
			}

			// Parameters match
			if (context.InstanceToValidate is T instanceToValidate) {
				return new ValidationContext<T>(instanceToValidate, context.PropertyChain, context.Selector) {
					IsChildContext = context.IsChildContext,
					RootContextData = context.RootContextData,
					_parentContext = context.ParentContext
				};
			}

			if (context.InstanceToValidate == null) {
				return new ValidationContext<T>(default, context.PropertyChain, context.Selector) {
					IsChildContext = context.IsChildContext,
					RootContextData = context.RootContextData,
					_parentContext = context.ParentContext
				};
			}

			throw new InvalidOperationException($"Cannot validate instances of type '{context.InstanceToValidate.GetType().Name}'. This validator can only validate instances of type '{typeof(T).Name}'.");
		}


		/// <summary>
		/// Creates a new validation context for use with a child validator
		/// </summary>
		/// <param name="instanceToValidate"></param>
		/// <param name="preserveParentContext"></param>
		/// <param name="selector"></param>
		/// <returns></returns>
		public ValidationContext<TChild> CloneForChildValidator<TChild>(TChild instanceToValidate, bool preserveParentContext = false, IValidatorSelector selector = null) {
			return new ValidationContext<TChild>(instanceToValidate, PropertyChain, selector ?? Selector) {
				IsChildContext = true,
				RootContextData = RootContextData,
				_parentContext = preserveParentContext ? this : null
			};
		}

		/// <summary>
		/// Creates a new validation context for use with a child collection validator
		/// </summary>
		/// <param name="instanceToValidate"></param>
		/// <param name="preserveParentContext"></param>
		/// <returns></returns>
		public ValidationContext<TNew> CloneForChildCollectionValidator<TNew>(TNew instanceToValidate, bool preserveParentContext = false) {
			return new ValidationContext<TNew>(instanceToValidate, null, Selector) {
				IsChildContext = true,
				IsChildCollectionContext = true,
				RootContextData = RootContextData,
				_parentContext = preserveParentContext ? this : null
			};
		}
	}
}