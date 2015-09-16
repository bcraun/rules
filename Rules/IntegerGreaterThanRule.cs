namespace ConsoleApplication1
{
    public class IntegerGreaterThanRule : BaseRule<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanRule"/> class.
        /// </summary>
        /// <param name="threshold">The threshold.</param>
        public IntegerGreaterThanRule(int threshold)
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
            Conditions.Clear();

            // Create our conditions
            var condition1 = new IntegerGreaterThanCondition(Threshold);

            // ...and add them to our collection of conditions
            Conditions.Add(condition1);
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