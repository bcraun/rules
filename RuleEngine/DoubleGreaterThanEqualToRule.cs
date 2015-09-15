namespace ConsoleApplication1
{
    public class DoubleGreaterThanEqualToRule : BaseRule<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleGreaterThanEqualToRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public DoubleGreaterThanEqualToRule(double threshold)
            : base(threshold)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override sealed void Initialize()
        {
            // Clear any existing conditions
            ClearConditions();

            // Create our conditions
            var condition1 = new DoubleGreaterThanCondition(Threshold);
            var condition2 = new DoubleEqualToCondition(Threshold);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
            Conditions.Add(condition2);
        }

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        public override bool MatchConditions()
        {
            return MatchesAnyCondition();
        }
    }
    public class DoubleEqualToRule : BaseRule<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleGreaterThanEqualToRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public DoubleEqualToRule(double threshold)
            : base(threshold)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public override sealed void Initialize()
        {
            // Clear any existing conditions
            ClearConditions();

            // Create our conditions
            var condition = new DoubleEqualToCondition(Threshold);

            // ...and add them to our collection of conditions
            Conditions.Add(condition);
        }

        /// <summary>
        /// Matches the conditions.
        /// </summary>
        /// <returns></returns>
        public override bool MatchConditions()
        {
            return MatchesAnyCondition();
        }
    }
}