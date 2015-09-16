using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public abstract class BaseRule<T> : IRule<T>
    {
        /// <summary>
        /// Gets or sets the value to apply the rule against.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Gets (or privately sets) the conditions which applies to the rule.
        /// </summary>
        /// <value>
        /// The conditions.
        /// </value>
        public IList<ICondition<T>> Conditions { get; }

        /// <summary>
        /// Gets (or privately sets) the threshold.
        /// </summary>
        /// <value>
        /// The threshold.
        /// </value>
        protected T Threshold { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRule{T}"/> class.
        /// </summary>
        protected BaseRule(T threshold)
        {
            // Set the threshold
            Threshold = threshold;

            // Instantiate the conditions collection
            Conditions = new List<ICondition<T>>();
        }

        /// <summary>
        /// Clears all of the conditions.
        /// </summary>
        public void ClearConditions()
        {
            Conditions.Clear();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Matches the conditions. 
        /// </summary>
        /// <returns><c>true</c> if the conditions are met for the specified value</returns>
        /// <remarks>Override this to call with rule specific implementation. 
        /// For example through to one of the protected methods "MatchAllConditions" 
        /// or "MatchesAnyCondition"
        /// </remarks>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual bool MatchConditions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Matches all of the rules.
        /// </summary>
        /// <returns><c>true</c> if all of the conditions are met for the specified value</returns>
        protected bool MatchAllConditions()
        {
            return Conditions.All(rule => rule.IsSatisfied);
        }

        /// <summary>
        /// Matches any of the rules.
        /// </summary>
        /// <returns><c>true</c> if any of the conditions are met for the specified value</returns>
        protected bool MatchesAnyCondition()
        {
            return Conditions.Any(rule => rule.IsSatisfied);
        }
    }
}
