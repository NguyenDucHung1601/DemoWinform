using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidationDLL {
    public abstract class ExcuteValidator<T> : IValidator<T>, IEnumerable<IValidationRule> {
		internal RuleCollection<IValidationRule> Rules { get; } = new RuleCollection<IValidationRule>();
        private Func<CascadeMode> _cascadeMode = () => ValidatorOptions.Global.CascadeMode;

        /// Sets the cascade mode for all rules within this validator.
        public CascadeMode CascadeMode {
            get => _cascadeMode();
            set => _cascadeMode = () => value;
        }
        bool IValidator.CanValidateInstancesOfType(Type type) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return typeof(T).IsAssignableFrom(type);
        }

        public IValidatorDescriptor CreateDescriptor() {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(T instance) {
            throw new NotImplementedException();
        }

        public ValidationResult Validate(IValidationContext context) {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default) {
            throw new NotImplementedException();
        }

        private void SetExecutedRulesets(ValidateResult result, ValidationContext<T> context) {
            var executed = context.RootContextData.GetOrAdd("_FV_RuleSetsExecuted", () => new HashSet<string> { RulesetValidatorSelector.DefaultRuleSetName });
            result.RuleSetsExecuted = executed.ToArray();
        }

        //============IEnumerable<IValidationRule>
        public IEnumerator<IValidationRule> GetEnumerator() {
            return Rules.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Defines a validation rule for a specify property.
        /// </summary>
        /// <example>
        /// RuleFor(x => x.Surname)...
        /// </example>
        /// <typeparam name="TProperty">The type of property being validated</typeparam>
        /// <param name="expression">The expression representing the property to validate</param>
        /// <returns>an IRuleBuilder instance on which validators can be defined</returns>
        public IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) {
            expression.Guard("Cannot pass null to RuleFor", nameof(expression));
            // If rule-level caching is enabled, then bypass the expression-level cache.
            // Otherwise we essentially end up caching expressions twice unnecessarily.
            var rule = PropertyRule.Create(expression, () => CascadeMode);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<T, TProperty>(rule, this);
            return ruleBuilder;
        }

        /// <summary>
        /// Invokes a rule for each item in the collection
        /// </summary>
        /// <typeparam name="TElement">Type of property</typeparam>
        /// <param name="expression">Expression representing the collection to validate</param>
        /// <returns>An IRuleBuilder instance on which validators can be defined</returns>
        public IRuleBuilderInitialCollection<T, TElement> RuleForEach<TElement>(Expression<Func<T, IEnumerable<TElement>>> expression) {
            expression.Guard("Cannot pass null to RuleForEach", nameof(expression));
            var rule = CollectionPropertyRule<T, TElement>.Create(expression, () => CascadeMode);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<T, TElement>(rule, this);
            return ruleBuilder;
        }

        /// <summary>
        /// Defines a RuleSet that can be used to group together several validators.
        /// </summary>
        /// <param name="ruleSetName">The name of the ruleset.</param>
        /// <param name="action">Action that encapsulates the rules in the ruleset.</param>
        public void RuleSet(string ruleSetName, Action action) {
            ruleSetName.Guard("A name must be specified when calling RuleSet.", nameof(ruleSetName));
            action.Guard("A ruleset definition must be specified when calling RuleSet.", nameof(action));

            var ruleSetNames = ruleSetName.Split(',', ';')
                .Select(x => x.Trim())
                .ToArray();

            using (Rules.OnItemAdded(r => r.RuleSets = ruleSetNames)) {
                action();
            }
        }

        /// <summary>
        /// Adds a rule to the current validator.
        /// </summary>
        /// <param name="rule"></param>
        protected void AddRule(IValidationRule rule) {
            Rules.Add(rule);
        }

    }
}