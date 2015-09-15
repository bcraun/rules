namespace ConsoleApplication1
{
    public class IntegerGreaterThanCondition : BaseCondition<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerGreaterThanCondition"/> class.
        /// </summary>
        /// <param name="threshold">The threshold value.</param>
        public IntegerGreaterThanCondition(int threshold)
            : base(threshold)
        {
        }

        /// <summary>
        /// Determines whether this instance is satisfied.
        /// </summary>
        /// <returns></returns>
        public override bool IsSatisfied => Value > Threshold;
    }
}